using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Animator))]
public class HandAnimation : MonoBehaviour
{
    [SerializeField] private InputActionReference gripReference;
    [SerializeField] private InputActionReference triggerReference;

    private Animator _handAnimator;

    private float _gripValue;
    private float _triggerValue;

    private void Start()
    {
        _handAnimator = GetComponent<Animator>();

        if (gripReference != null && gripReference.action != null)
            gripReference.action.Enable();

        if (triggerReference != null && triggerReference.action != null) 
            triggerReference.action.Enable();
    }

    private void Update()
    {
        if (gripReference != null && gripReference.action != null)
            AnimateGrip();
        if (triggerReference != null && triggerReference.action != null)
            AnimateTrigger();
    }

    private void AnimateGrip()
    {
        _gripValue = gripReference.action.ReadValue<float>();
        _handAnimator.SetFloat("Grip", _gripValue);
    }

    private void AnimateTrigger()
    {
        _triggerValue = triggerReference.action.ReadValue<float>();
        _handAnimator.SetFloat("Trigger", _triggerValue);
    }
}
