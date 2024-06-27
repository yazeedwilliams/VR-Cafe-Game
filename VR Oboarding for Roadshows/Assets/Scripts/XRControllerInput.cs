using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class XRControllerInput : MonoBehaviour
{
    public InputDevice rightController;
    public InputDevice leftController;

    private InputData inputData;

    private void Start()
    {
        inputData = GetComponent<InputData>();
        Debug.Log(inputData);
    }

    private void Update()
    {
        if (inputData._leftController.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue))
        {
            Debug.Log("trigger value" + triggerValue);
        }
    }
}
