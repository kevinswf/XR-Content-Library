using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using TMPro;

public class Scanner : XRGrabInteractable
{

    [Header("Scanner Data")]
    public Animator animator;
    public LineRenderer laserRenderer;
    public TextMeshProUGUI targetName;
    public TextMeshProUGUI targetPos;

    protected override void Awake()
    {
        base.Awake();

        // disable scanner on start
        ScannerActivated(false);
    }

    public override void ProcessInteractable(XRInteractionUpdateOrder.UpdatePhase updatePhase)
    {
        base.ProcessInteractable(updatePhase);

        // if laser is activated, keep scanning for objects
        if (laserRenderer.gameObject.activeSelf)
        {
            ScanForObjects();
        }
    }

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);

        // open the screen when grabbed
        animator.SetBool("Opened", true);
    }

    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        base.OnSelectExited(args);

        // close the screen when released
        animator.SetBool("Opened", false);
    }

    protected override void OnActivated(ActivateEventArgs args)
    {
        base.OnActivated(args);

        ScannerActivated(true);
    }

    protected override void OnDeactivated(DeactivateEventArgs args)
    {
        base.OnDeactivated(args);

        ScannerActivated(false);
    }

    private void ScannerActivated(bool isActivated)
    {
        // enable/disable laser
        laserRenderer.gameObject.SetActive(isActivated);

        // enable/disable screen text
        targetName.gameObject.SetActive(isActivated);
        targetPos.gameObject.SetActive(isActivated);
    }

    private void ScanForObjects()
    {
        RaycastHit hit;

        // if nothing is hit, extend ray until this point
        Vector3 worldHit = laserRenderer.transform.position + laserRenderer.transform.forward * 1000.0f;

        if (Physics.Raycast(laserRenderer.transform.position, laserRenderer.transform.forward, out hit))
        {
            targetName.SetText(hit.collider.name);
            targetPos.SetText(hit.collider.transform.position.ToString());

            // set the endpoint for the laser renderer
            worldHit = hit.point;
            laserRenderer.SetPosition(1, laserRenderer.transform.InverseTransformPoint(worldHit));
        }
    }
}
