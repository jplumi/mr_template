using Oculus.Interaction;
using UnityEngine;

public class ControllerScript : MonoBehaviour
{
    [SerializeField] private OVRInput.Controller controller;
    [Header("Rotate")]
    [SerializeField] private float rotateSpeed = 100.0f;
    [Header("Scale")]
    [SerializeField] private float minScaleSize = 0.05f;
    [SerializeField] private float maxScaleSize = 1.5f;
    [SerializeField] private float scaleSpeed = 1f;

    private Vector3 targetPosition;
    private Quaternion targetRotation;
    private float step;

    private GameObject currentInteractable;

    private float interactableDistance = 0f;

    private Vector2 thumbstickInput = Vector2.zero;

    void Update()
    {
        if(currentInteractable != null)
        {
            thumbstickInput = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, controller);
            MoveObject();
            RotateAndScaleObj();

            if(OVRInput.GetUp(OVRInput.Button.One, controller))
            {
                if(currentInteractable.TryGetComponent(out ChangeLayers changeLayers))
                {
                    changeLayers.DownLayer();
                }
            }
            if(OVRInput.GetUp(OVRInput.Button.Two, controller))
            {
                if(currentInteractable.TryGetComponent(out ChangeLayers changeLayers))
                {
                    changeLayers.UpLayer();
                }
            }
        }
    }

    private void MoveObject()
    {
        step = 5.0f * Time.deltaTime;
        targetPosition = transform.position + transform.transform.forward * interactableDistance;
        currentInteractable.transform.position = Vector3.Lerp(currentInteractable.transform.position, targetPosition, step);
    }

    private void RotateAndScaleObj()
    {
        if(OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, controller) >= 0.2f)
        {
            float horizontalRotation = thumbstickInput.x * Time.deltaTime * rotateSpeed;
            currentInteractable.transform.Rotate(0, horizontalRotation, 0);
        } 
        else if(thumbstickInput.y != 0)
        {
            float scaleValue = currentInteractable.transform.localScale.x + thumbstickInput.y * Time.deltaTime * scaleSpeed;
            float currentScale = Mathf.Clamp(scaleValue, minScaleSize, maxScaleSize);
            currentInteractable.transform.localScale = new Vector3(currentScale, currentScale, currentScale);
        }
    }

    public void OnInteractableSelected(RayInteractable interactable)
    {
        currentInteractable = interactable.gameObject;
        interactableDistance = Vector3.Distance(transform.position, currentInteractable.transform.position);
    }
    public void OnInteractableUnselected(RayInteractable interactable)
    {
        currentInteractable = null;
    }
}