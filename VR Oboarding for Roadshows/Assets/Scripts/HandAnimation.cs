using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Animator))]
public class HandAnimation : MonoBehaviour
{
    [SerializeField] private InputActionReference gripReference;
    //[SerializeField] private InputActionReference triggerReference;

    private Animator _handAnimator;

    private float _gripValue;
    private float _triggerValue;

    private void Start()
    {
        _handAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        AnimateGrip();
    }

    private void AnimateGrip()
    {
        _gripValue = gripReference.action.ReadValue<float>();
        _handAnimator.SetFloat("Grip", _gripValue);
    }
}
