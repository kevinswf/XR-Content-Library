using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(XRRayInteractor))]
public class ToggleRaycast : MonoBehaviour
{
    [SerializeField]
    private XRDirectInteractor directInteractor = null;

    private XRRayInteractor rayInteractor = null;
    private bool rayActivated = false;

    void Awake()
    {
        rayInteractor = GetComponent<XRRayInteractor>();
    }

    public void ToggleInteractors()
    {
        rayActivated = !rayActivated;

        rayInteractor.enabled = rayActivated;
        directInteractor.enabled = !rayActivated;
    }
}
