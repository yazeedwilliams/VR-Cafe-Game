using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class TutorialManager : MonoBehaviour
{
    [SerializeField] private GameObject[] instructionsText;
    [SerializeField] private AudioClip[] stepAudioClips;
    [SerializeField] private GameObject[] highlightedButtons;
    [SerializeField] private XRControllerButtonInput buttonInput;
    [SerializeField] private AudioSource audioSource;

    private float deactivateTime = 5f;
    private int currentStep = 0;

    private void Start()
    {
        if (instructionsText.Length == 0)
        {
            Debug.LogError("instructionsText array is empty.");
            return;
        }

        instructionsText[currentStep].SetActive(true);
        StartCoroutine(DeactivateAfterDelay(deactivateTime));


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
        }
        else if (currentStep == 2 && instructionsText[2].activeSelf &&
                 (actionReference == buttonInput.leftGripButtonAction || actionReference == buttonInput.rightGripButtonAction))
        {
            MoveToNextStep();
        }
        else if (currentStep == 3 && instructionsText[3].activeSelf &&
                 (actionReference == buttonInput.leftPrimaryButtonAction || actionReference == buttonInput.rightPrimaryButtonAction))
        {
            MoveToNextStep();
        }
        else if (currentStep == 4 && instructionsText[4].activeSelf &&
                 (actionReference == buttonInput.leftSecondaryButtonAction || actionReference == buttonInput.rightSecondaryButtonAction))
        {
            MoveToNextStep();
        }
        else if (currentStep == 5 && instructionsText[5].activeSelf &&
                 (actionReference == buttonInput.leftSecondaryButtonAction || actionReference == buttonInput.rightSecondaryButtonAction))
        {
            MoveToNextStep();
        }
        else if (currentStep == 6 && instructionsText[6].activeSelf &&
                 (actionReference == buttonInput.leftAnalogueButtonAction || actionReference == buttonInput.rightAnalogueButtonAction))
        {
            MoveToNextStep();
        }
    }

    private void MoveToNextStep()
    {
        instructionsText[currentStep].SetActive(false);
        //highlightedButtons[currentStep].SetActive(false);
        currentStep++;
        if (currentStep < instructionsText.Length)
        {
            highlightedButtons[currentStep - 1].SetActive(true);
            instructionsText[currentStep].SetActive(true);
            PlayStepAudio(currentStep);
        }
        highlightedButtons[currentStep - 1].SetActive(false);

        if (currentStep == instructionsText.Length)
            Debug.Log("Finished");
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
    }
}
