using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchProjectile : MonoBehaviour
{
    [SerializeField]
    private GameObject projectilePrefab = null;
    [SerializeField]
    private Transform launchPoint = null;
    [SerializeField]
    private float launchSpeed = 500.0f;

    public void Launch()
    {
        GameObject newProjectile = Instantiate(projectilePrefab, launchPoint.position, launchPoint.rotation);

        // add force to the new projectile
        if (newProjectile.TryGetComponent(out Rigidbody rigidBody))
            rigidBody.AddForce(launchPoint.forward * launchSpeed);
    }
}
