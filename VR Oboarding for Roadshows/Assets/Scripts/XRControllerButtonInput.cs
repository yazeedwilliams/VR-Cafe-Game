using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class XRControllerButtonInput : MonoBehaviour
{
    public event Action<InputActionReference> OnButtonPressEvent;

    [Header("Left Controller Actions")]
    public InputActionReference leftTriggerButtonAction;
    public InputActionReference leftGripButtonAction;
    public InputActionReference leftPrimaryButtonAction;
    public InputActionReference leftSecondaryButtonAction;
    public InputActionReference leftAnalogueButtonAction;

    [Header("Right Controller Actions")]
    public InputActionReference rightTriggerButtonAction;
    public InputActionReference rightGripButtonAction;
    public InputActionReference rightPrimaryButtonAction;
    public InputActionReference rightSecondaryButtonAction;
    public InputActionReference rightAnalogueButtonAction;

    private Dictionary<InputActionReference, Action<InputAction.CallbackContext>> leftActionHandlers;
    private Dictionary<InputActionReference, Action<InputAction.CallbackContext>> rightActionHandlers;

    private void Awake()
    {
        leftActionHandlers = new Dictionary<InputActionReference, Action<InputAction.CallbackContext>>
        {
            { leftTriggerButtonAction, context => OnButtonPress(context, leftTriggerButtonAction) },
            { leftGripButtonAction, context => OnButtonPress(context, leftGripButtonAction) },
            { leftPrimaryButtonAction, context => OnButtonPress(context, leftPrimaryButtonAction) },
            { leftSecondaryButtonAction, context => OnButtonPress(context, leftSecondaryButtonAction) },
            { leftAnalogueButtonAction, context => OnButtonPress(context, leftAnalogueButtonAction) }
        };

        rightActionHandlers = new Dictionary<InputActionReference, Action<InputAction.CallbackContext>>
        {
            { rightTriggerButtonAction, context => OnButtonPress(context, rightTriggerButtonAction) },
            { rightGripButtonAction, context => OnButtonPress(context, rightGripButtonAction) },
            { rightPrimaryButtonAction, context => OnButtonPress(context, rightPrimaryButtonAction) },
            { rightSecondaryButtonAction, context => OnButtonPress(context, rightSecondaryButtonAction) },
            { rightAnalogueButtonAction, context => OnButtonPress(context, rightAnalogueButtonAction) }
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

    private void OnButtonPress(InputAction.CallbackContext context, InputActionReference actionReference)
    {
        if (context.performed)
        {
            if (actionReference == leftTriggerButtonAction || actionReference == rightTriggerButtonAction)
            {
                OnButtonPressEvent?.Invoke(actionReference);
            }
            else if (actionReference == leftGripButtonAction || actionReference == rightGripButtonAction)
            {
                OnButtonPressEvent?.Invoke(actionReference);
            }
            else if (actionReference == leftPrimaryButtonAction || actionReference == rightPrimaryButtonAction)
            {
                OnButtonPressEvent?.Invoke(actionReference);
            }
            else if (actionReference == leftSecondaryButtonAction || actionReference == rightSecondaryButtonAction)
            {
                OnButtonPressEvent?.Invoke(actionReference);
            }
            else if (actionReference == leftAnalogueButtonAction || actionReference == rightAnalogueButtonAction)
            {
                OnButtonPressEvent?.Invoke(actionReference);
            }
        }
    }
}
