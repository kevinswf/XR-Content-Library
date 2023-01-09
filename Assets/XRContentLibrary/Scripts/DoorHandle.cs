using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DoorHandle : XRBaseInteractable
{
    [SerializeField]
    private GameObject lockObject;
    [SerializeField]
    private Vector3 doorOpenLocalDirection;
    [SerializeField]
    private float doorWeight;
    [SerializeField]
    private Transform doorTransform;
    [SerializeField]
    private float totalDragDistance;

    private bool unlocked = false;
    private Vector3 doorClosePos;
    private Vector3 doorOpenPos;
    private Vector3 doorOpenWorldDirection;



    protected override void OnEnable()
    {
        base.OnEnable();

        CardReader.onCardSwiped += UnlockDoor;
    }

    protected override void OnDisable()
    {
        base.OnDisable();

        CardReader.onCardSwiped -= UnlockDoor;
    }

    private void Start()
    {
        // transform the door open direction from local to world space
        doorOpenWorldDirection = transform.TransformDirection(doorOpenLocalDirection).normalized;

        // init the door's pos and open and close
        doorClosePos = doorTransform.position;
        doorOpenPos = doorTransform.position + doorOpenWorldDirection * totalDragDistance;
    }

    private void UnlockDoor()
    {
        unlocked = true;

        // hide the lock to indicate door is unlocked
        lockObject.SetActive(false);
    }

    public override void ProcessInteractable(XRInteractionUpdateOrder.UpdatePhase updatePhase)
    {
        base.ProcessInteractable(updatePhase);

        if (unlocked && isSelected)
        {
            // get the hand's location
            Transform interactorTransform = firstInteractorSelecting.GetAttachTransform(this);

            // get the vector between hand and the door handle
            Vector3 handToHandle = interactorTransform.position - transform.position;

            // calculate the dot product between that vector and the door open direction
            float dragVector = Vector3.Dot(handToHandle, doorOpenWorldDirection);

            // whether opening or closing
            bool opening = dragVector > 0.0f;

            // calculate the dragging magnitude
            float dragMagnitude = Mathf.Abs(dragVector);

            // calculate moving speed based on dragging magnitude
            float speed = dragMagnitude / Time.deltaTime / doorWeight;

            // move the door
            doorTransform.position = Vector3.MoveTowards(doorTransform.position, opening ? doorOpenPos : doorClosePos, speed * Time.deltaTime);
        }
    }

}
