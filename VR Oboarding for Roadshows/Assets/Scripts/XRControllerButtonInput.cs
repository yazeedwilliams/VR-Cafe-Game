using UnityEngine;
using UnityEngine.InputSystem;

public class XRControllerButtonInput : MonoBehaviour
{
    [SerializeField] private InputActionReference triggerButtonAction;

    private void OnEnable()
    {
        triggerButtonAction.action.performed += OnButtonPress;
    }

    private void OnDisable()
    {
        triggerButtonAction.action.performed -= OnButtonPress;
    }

    private void OnButtonPress(InputAction.CallbackContext context)
    {
        if (context.performed)
            Debug.Log("Pressed");
    }
}
