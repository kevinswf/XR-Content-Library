using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CardReader : XRSocketInteractor
{
    [SerializeField]
    private float marginError = 0.3f;

    private Transform keycardTransform = null;
    private Vector3 swipeBeginPoint;
    private bool validSwipe;

    public delegate void CardSwiped();
    public static event CardSwiped onCardSwiped;


    protected override void OnHoverEntered(HoverEnterEventArgs args)
    {
        base.OnHoverEntered(args);

        // get the card's transform, and set swipe begin point
        keycardTransform = args.interactableObject.transform;
        swipeBeginPoint = keycardTransform.position;

        // init to valid swipe
        validSwipe = true;
    }

    protected override void OnHoverExited(HoverExitEventArgs args)
    {
        base.OnHoverExited(args);

        // get the total swipe vertical distance
        Vector3 swipeVector = keycardTransform.position - swipeBeginPoint;

        // if valid swipe and swipe distance greater than threshold
        if (validSwipe && swipeVector.y < -0.15f)
        {
            // valid swipe to unlock door
            if (onCardSwiped != null)
            {
                onCardSwiped();
            }
        }

        // end swiping
        keycardTransform = null;
    }

    private void Update()
    {
        // if the keycard is currently swiping, keep checking it is a valid swipe, by checking that the angle between card and card reader is valid
        if (keycardTransform != null)
        {
            Vector3 keycardUp = keycardTransform.forward;

            // dot product between keycard up and world up should be 1 to be correct swipe (parallel), i.e. not too slanted
            float dot = Vector3.Dot(keycardUp, Vector3.up);

            // if card too slanted, not a valid swipe
            if (dot < 1 - marginError)
            {
                validSwipe = false;
            }
        }
    }
}
