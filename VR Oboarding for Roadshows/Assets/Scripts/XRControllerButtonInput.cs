using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class XRControllerButtonInput : MonoBehaviour
{
    [SerializeField] private InputActionReference triggerButtonAction;
    [SerializeField] private InputActionReference gripButtonAction; 
    [SerializeField] private InputActionReference primaryButtonAction;
    [SerializeField] private InputActionReference secondaryButtonAction; 
    [SerializeField] private InputActionReference analogueButtonAction;

    private void OnEnable()
    {
        triggerButtonAction.action.performed += OnTriggerButtonPress;
        gripButtonAction.action.performed += OnGripButtonPress;
        primaryButtonAction.action.performed += OnPrimaryButtonPress;
        secondaryButtonAction.action.performed += OnSecondaryButtonPress;
        analogueButtonAction.action.performed += OnAnaloguepressed;
    }

    private void OnDisable()
    {
        triggerButtonAction.action.performed -= OnTriggerButtonPress;
        gripButtonAction.action.performed -= OnGripButtonPress;
        primaryButtonAction.action.performed -= OnPrimaryButtonPress;
        secondaryButtonAction.action.performed -= OnSecondaryButtonPress;
        analogueButtonAction.action.performed -= OnAnaloguepressed;
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

    private void OnAnaloguepressed(InputAction.CallbackContext context)
    {
        if (context.performed)
            Debug.Log("Analogue Pressed");
    }

}
