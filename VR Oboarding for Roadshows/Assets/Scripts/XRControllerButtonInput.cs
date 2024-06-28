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
        triggerButtonAction.action.performed += OnButtonPress;
        gripButtonAction.action.performed += OnButtonPress;
        primaryButtonAction.action.performed += OnButtonPress;
        secondaryButtonAction.action.performed += OnButtonPress;
        analogueButtonAction.action.performed += OnButtonPress;
    }

    private void OnDisable()
    {
        triggerButtonAction.action.performed -= OnButtonPress;
        gripButtonAction.action.performed -= OnButtonPress;
        primaryButtonAction.action.performed -= OnButtonPress;
        secondaryButtonAction.action.performed -= OnButtonPress;
        analogueButtonAction.action.performed -= OnButtonPress;
    }

    private void OnButtonPress(InputAction.CallbackContext context)
    {
        if (context.performed)
            Debug.Log("Pressed");
    }
}
