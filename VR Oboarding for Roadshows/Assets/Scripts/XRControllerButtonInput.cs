using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class XRControllerButtonInput : MonoBehaviour
{
    [Header("Left Controller Actions")]
    [SerializeField] private InputActionReference leftTriggerButtonAction;
    [SerializeField] private InputActionReference leftGripButtonAction;
    [SerializeField] private InputActionReference leftPrimaryButtonAction;
    [SerializeField] private InputActionReference leftSecondaryButtonAction;
    [SerializeField] private InputActionReference leftAnalogueButtonAction;

    [Header("Right Controller Actions")]
    [SerializeField] private InputActionReference rightTriggerButtonAction;
    [SerializeField] private InputActionReference rightGripButtonAction;
    [SerializeField] private InputActionReference rightPrimaryButtonAction;
    [SerializeField] private InputActionReference rightSecondaryButtonAction;
    [SerializeField] private InputActionReference rightAnalogueButtonAction;

    private Dictionary<InputActionReference, Action<InputAction.CallbackContext>> leftActionHandlers;
    private Dictionary<InputActionReference, Action<InputAction.CallbackContext>> rightActionHandlers;

    private void Awake()
    {
        leftActionHandlers = new Dictionary<InputActionReference, Action<InputAction.CallbackContext>>
        {
            { leftTriggerButtonAction, context => OnButtonPress(context, "Left Trigger Pressed") },
            { leftGripButtonAction, context => OnButtonPress(context, "Left Grip Pressed") },
            { leftPrimaryButtonAction, context => OnButtonPress(context, "Left Primary Pressed") },
            { leftSecondaryButtonAction, context => OnButtonPress(context, "Left Secondary Pressed") },
            { leftAnalogueButtonAction, context => OnButtonPress(context, "Left Analogue Pressed") }
        };

        rightActionHandlers = new Dictionary<InputActionReference, Action<InputAction.CallbackContext>>
        {
            { rightTriggerButtonAction, context => OnButtonPress(context, "Right Trigger Pressed") },
            { rightGripButtonAction, context => OnButtonPress(context, "Right Grip Pressed") },
            { rightPrimaryButtonAction, context => OnButtonPress(context, "Right Primary Pressed") },
            { rightSecondaryButtonAction, context => OnButtonPress(context, "Right Secondary Pressed") },
            { rightAnalogueButtonAction, context => OnButtonPress(context, "Right Analogue Pressed") }
        };
    }

    private void OnEnable()
    {
        foreach (var actionHandler in leftActionHandlers)
        {
            actionHandler.Key.action.performed += actionHandler.Value;
        }

        foreach (var actionHandler in rightActionHandlers)
        {
            actionHandler.Key.action.performed += actionHandler.Value;
        }
    }

    private void OnDisable()
    {
        foreach (var actionHandler in leftActionHandlers)
        {
            actionHandler.Key.action.performed -= actionHandler.Value;
        }

        foreach (var actionHandler in rightActionHandlers)
        {
            actionHandler.Key.action.performed -= actionHandler.Value;
        }
    }

    private void OnButtonPress(InputAction.CallbackContext context, string message)
    {
        if (context.performed)
        {
            Debug.Log(message);
        }
    }
}
