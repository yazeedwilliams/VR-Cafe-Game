using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class TutorialManager : MonoBehaviour
{
    [SerializeField] private GameObject[] instructionsText;
    [SerializeField] private AudioClip[] stepAudioClips;
    [SerializeField] private GameObject[] highlightedButtons;
    [SerializeField] private XRControllerButtonInput buttonInput;
    [SerializeField] private AudioSource audioSource;

    private float timeDelay = 4f;
    private int currentStep = 0;
    private int highlightedButtonsIndex = 0;

    private void Start()
    {
        if (instructionsText.Length == 0)
        {
            Debug.LogError("instructionsText array is empty.");
            return;
        }

        instructionsText[currentStep].SetActive(true);
        StartCoroutine(DeactivateAfterDelay(timeDelay));


        // Subscribe to button press events
        if (buttonInput != null)
        {
            buttonInput.OnButtonPressEvent += HandleButtonPress;
        }
    }

    private void OnDestroy()
    {
        if (buttonInput != null)
        {
            buttonInput.OnButtonPressEvent -= HandleButtonPress;
        }
    }

    private void HandleButtonPress(InputActionReference actionReference)
    {
        if (currentStep >= instructionsText.Length)
        {
            Debug.LogError("Current step is out of range.");
            return;
        }

        if (currentStep == 1 && instructionsText[1].activeSelf &&
            (actionReference == buttonInput.leftTriggerButtonAction || actionReference == buttonInput.rightTriggerButtonAction))
        {
            MoveToNextStep();
            ChangeHighlightButton();
        }
        else if (currentStep == 2 && instructionsText[2].activeSelf &&
                 (actionReference == buttonInput.leftGripButtonAction || actionReference == buttonInput.rightGripButtonAction))
        {
            MoveToNextStep();
            ChangeHighlightButton();
        }
        else if (currentStep == 3 && instructionsText[3].activeSelf &&
                 (actionReference == buttonInput.leftPrimaryButtonAction || actionReference == buttonInput.rightPrimaryButtonAction))
        {
            MoveToNextStep();
            ChangeHighlightButton();
        }
        else if (currentStep == 4 && instructionsText[4].activeSelf &&
                 (actionReference == buttonInput.leftSecondaryButtonAction || actionReference == buttonInput.rightSecondaryButtonAction))
        {
            MoveToNextStep();
            ChangeHighlightButton();
        }
        else if (currentStep == 5 && instructionsText[5].activeSelf &&
                 (actionReference == buttonInput.leftSecondaryButtonAction || actionReference == buttonInput.rightSecondaryButtonAction))
        {
            MoveToNextStep();
            ChangeHighlightButton();
        }
        else if (currentStep == 6 && instructionsText[6].activeSelf &&
                 (actionReference == buttonInput.leftAnalogueButtonAction || actionReference == buttonInput.rightAnalogueButtonAction))
        {
            MoveToNextStep();
            ChangeHighlightButton();
        }
    }

    private void MoveToNextStep()
    {
        instructionsText[currentStep].SetActive(false);
        currentStep++;
        if (currentStep < instructionsText.Length)
        {
            instructionsText[currentStep].SetActive(true);
            PlayStepAudio(currentStep);
        }

        if (currentStep == 6)
            StartCoroutine(ChangeScene(timeDelay));
    }

    private void ChangeHighlightButton()
    {
        if (highlightedButtonsIndex < highlightedButtons.Length)
        {
            if (highlightedButtonsIndex > 0)
                highlightedButtons[highlightedButtonsIndex - 1].SetActive(false);
            highlightedButtons[highlightedButtonsIndex].SetActive(true);
            highlightedButtonsIndex++;
        }
    }

    private void PlayStepAudio(int step)
    {
        if (stepAudioClips.Length > step && stepAudioClips[step] != null && audioSource != null)
        {
            audioSource.clip = stepAudioClips[step];
            audioSource.Play();
        }
    }

    private IEnumerator DeactivateAfterDelay(float delay)
    {
        PlayStepAudio(currentStep);
        yield return new WaitForSeconds(delay);
        MoveToNextStep();
        ChangeHighlightButton();
    }

    private IEnumerator ChangeScene(float delay)
    {
        yield return new WaitForSeconds(delay);
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("LevelOne");
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
