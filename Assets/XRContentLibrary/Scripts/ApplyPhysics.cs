using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// this script toggles physics of a rigidbody
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public class ApplyPhysics : MonoBehaviour
{
    private Rigidbody rb = null;
    private CollisionDetectionMode defaultMode = CollisionDetectionMode.Discrete;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        defaultMode = rb.collisionDetectionMode;
    }

    public void EnablePhysics()
    {
        rb.collisionDetectionMode = defaultMode;
        rb.useGravity = true;
        rb.isKinematic = false;
    }

    public void DisablePhysics()
    {
        rb.collisionDetectionMode = CollisionDetectionMode.Discrete;
        rb.useGravity = false;
        rb.isKinematic = true;
    }
}
