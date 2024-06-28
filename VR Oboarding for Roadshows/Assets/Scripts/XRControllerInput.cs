using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class XRControllerInput : MonoBehaviour
{
    private InputDevice rightController;
    private InputDevice leftController;

    private void Start()
    {
        rightController = InitalizeController();
    }

    private InputDevice InitalizeController()
    {
        List<InputDevice> controllers = new List<InputDevice>();
        InputDevices.GetDevicesAtXRNode(XRNode.GameController, controllers);
        if (controllers.Count > 0)
        {
            rightController = controllers[0];
            Debug.Log("Controller initialized");
        }
        return rightController;
    }
}
