using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class TutorialManager : MonoBehaviour
{
    [SerializeField] private GameObject[] instructionsText;
    [SerializeField] private XRControllerButtonInput buttonInput;

    private void Start()
    {
        if (instructionsText.Length > 0)
        {
            instructionsText[0].SetActive(true);
        }

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
        if (actionReference == buttonInput.leftTriggerButtonAction || actionReference == buttonInput.rightTriggerButtonAction)
        {
            instructionsText[0].SetActive(false);
            instructionsText[1].SetActive(true);
        }
        else if (actionReference == buttonInput.leftGripButtonAction || actionReference == buttonInput.rightGripButtonAction)
        {
            instructionsText[1].SetActive(false);
            instructionsText[2].SetActive(true);
        }
        else if (actionReference == buttonInput.leftSecondaryButtonAction || actionReference == buttonInput.rightSecondaryButtonAction)
        {
            instructionsText[2].SetActive(false);
            instructionsText[3].SetActive(true);
        }
        else if (actionReference == buttonInput.leftPrimaryButtonAction || actionReference == buttonInput.rightPrimaryButtonAction)
        {
            instructionsText[3].SetActive(false);
            instructionsText[4].SetActive(true);
        }
        else if (actionReference == buttonInput.leftAnalogueButtonAction || actionReference == buttonInput.rightAnalogueButtonAction)
        {
            instructionsText[4].SetActive(false);
            instructionsText[5].SetActive(true);
        }
    }
}
