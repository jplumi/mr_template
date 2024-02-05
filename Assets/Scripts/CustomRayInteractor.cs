using System;
using Oculus.Interaction;
using UnityEngine;
using UnityEngine.Events;

public class CustomRayInteractor : RayInteractor
{
    [Header("Events")]
    public UnityEvent<RayInteractable> OnInteractableSelected;
    public UnityEvent<RayInteractable> OnInteractableUnselected;
    
    protected override void InteractableSelected(RayInteractable interactable)
    {
        base.InteractableSelected(interactable);
        OnInteractableSelected?.Invoke(interactable);
    }

    protected override void InteractableUnselected(RayInteractable interactable)
    {
        base.InteractableUnselected(interactable);
        OnInteractableUnselected?.Invoke(interactable);
    }
}