using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ballon : MonoBehaviour
{
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
        rb.useGravity = false;
    }

    public void Detach()
    {
        transform.SetParent(null);

        // float the ballon
        rb.isKinematic = false;
        var force = gameObject.AddComponent<ConstantForce>();
        force.force = Vector3.up;
    }
}
