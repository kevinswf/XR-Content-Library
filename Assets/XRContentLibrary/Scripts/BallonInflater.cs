using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class BallonInflater : XRGrabInteractable
{
    [Header("Ballon Data")]
    [SerializeField]
    private Transform attachPoint;
    [SerializeField]
    private Ballon ballonPrefab;

    private Ballon ballonInstance;
    private XRBaseController controller;

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);

        // create a new ballon when inflater is selected
        ballonInstance = Instantiate(ballonPrefab, attachPoint);

        // get the controller that is holding the inflater (left or right)
        XRBaseControllerInteractor controllerInteractor = args.interactorObject as XRBaseControllerInteractor;
        controller = controllerInteractor.xrController;
    }

    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        base.OnSelectExited(args);

        Destroy(ballonInstance.gameObject);
    }

    public override void ProcessInteractable(XRInteractionUpdateOrder.UpdatePhase updatePhase)
    {
        base.ProcessInteractable(updatePhase);

        if (ballonInstance != null)
            ballonInstance.transform.localScale = Vector3.one * Mathf.Lerp(1.0f, 4.0f, controller.activateInteractionState.value);
    }

    public void DetachBallon()
    {
        if (ballonInstance != null)
        {
            ballonInstance.Detach();
            ballonInstance = null;
            StartCoroutine(NewBallon());
        }
    }

    private IEnumerator NewBallon()
    {
        yield return new WaitForSeconds(1);
        ballonInstance = Instantiate(ballonPrefab, attachPoint);
    }
}
