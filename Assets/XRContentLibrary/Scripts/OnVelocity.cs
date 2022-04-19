using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]
public class OnVelocity : MonoBehaviour
{
    /* thresholds for triggering the OnVelocity event */
    [SerializeField]
    private float beginVelocityThreshold = 1.25f;
    [SerializeField]
    private float endVelocityThreshold = 0.25f;

    [SerializeField]
    private UnityEvent OnBegin = new UnityEvent();
    [SerializeField]
    private UnityEvent OnEnd = new UnityEvent();

    private Rigidbody rb = null;
    // keep track if velocity has reached the OnBegin, and is in motion
    private bool inVelocity = false;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        CheckVelocity();
    }

    private void CheckVelocity()
    {
        float speed = rb.velocity.magnitude;

        inVelocity = HasVelocityBegun(speed);

        if(HasVelocityEnded(speed))
            inVelocity = false;
    }

    private bool HasVelocityBegun(float speed)
    {
        if(inVelocity)
            return true;

        bool hasBegun = speed > beginVelocityThreshold;

        // trigger event for OnVelocityBegan
        if(hasBegun)
            OnBegin.Invoke();

        return hasBegun;
    }

    private bool HasVelocityEnded(float speed)
    {
        // if velocity has not reached to threshold of hasBegun, then OnEnd cannot be triggered (even at low velocity)
        if(!inVelocity)
            return false;

        bool hasEnded = speed < endVelocityThreshold;

        // trigger event for OnVelocityEnd
        if(hasEnded)
            OnEnd.Invoke();

        return hasEnded;
    }
}
