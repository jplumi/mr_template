using System.Collections;
using System.Collections.Generic;
using Oculus.Interaction;
using UnityEngine;

public class RightControllerGrab : MonoBehaviour
{
    public void OnSelected(RayInteractable interactable)
    {
        OVRInput.SetControllerVibration(1, 1, OVRInput.Controller.RTouch);
    }
}
