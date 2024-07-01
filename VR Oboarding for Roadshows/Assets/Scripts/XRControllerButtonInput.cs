using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class XRControllerButtonInput : MonoBehaviour
{
    [SerializeField] private InputActionReference triggerButtonAction;
    [SerializeField] private InputActionReference gripButtonAction;
    [SerializeField] private InputActionReference primaryButtonAction;
    [SerializeField] private InputActionReference secondaryButtonAction;
    [SerializeField] private InputActionReference analogueButtonAction;

    private Dictionary<InputActionReference, Action<InputAction.CallbackContext>> actionHandlers;

    private void Awake()
    {
        actionHandlers = new Dictionary<InputActionReference, Action<InputAction.CallbackContext>>
        {
            { triggerButtonAction, OnTriggerButtonPress },
            { gripButtonAction, OnGripButtonPress },
            { primaryButtonAction, OnPrimaryButtonPress },
            { secondaryButtonAction, OnSecondaryButtonPress },
            { analogueButtonAction, OnAnaloguePressed }
        };
    }

    private void OnEnable()
    {
        foreach (var actionHandler in actionHandlers)
        {
            actionHandler.Key.action.performed += actionHandler.Value;
        }
    }

    private void OnDisable()
    {
        foreach (var actionHandler in actionHandlers)
        {
            actionHandler.Key.action.performed -= actionHandler.Value;
        }
    }

    private void OnTriggerButtonPress(InputAction.CallbackContext context)
    {
        if (context.performed)
            Debug.Log("Trigger Pressed");
    }

    private void OnGripButtonPress(InputAction.CallbackContext context)
    {
        if (context.performed)
            Debug.Log("Grip Pressed");
    }

    private void OnPrimaryButtonPress(InputAction.CallbackContext context)
    {
        if (context.performed)
            Debug.Log("Primary Pressed");
    }

    private void OnSecondaryButtonPress(InputAction.CallbackContext context)
    {
        if (context.performed)
            Debug.Log("Secondary Pressed");
    }

    private void OnAnaloguePressed(InputAction.CallbackContext context)
    {
        if (context.performed)
            Debug.Log("Analogue Pressed");
    }
}
