using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TouchButton : XRBaseInteractable
{
    [Header("Button Data")]
    [SerializeField]
    private int buttonNumber;

    [SerializeField]
    private Material hoverMaterial;
    [SerializeField]
    private Material nonHoverMaterial;

    private MeshRenderer meshRenderer;

    public delegate void ButtonPressed(int number);
    public static event ButtonPressed onButtonPress;

    protected override void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();

    }

    protected override void OnEnable()
    {
        base.OnEnable();

        hoverEntered.AddListener(StartHover);
        hoverExited.AddListener(EndHover);
    }

    protected override void OnDisable()
    {
        hoverEntered.RemoveListener(StartHover);
        hoverExited.RemoveListener(EndHover);

        base.OnDisable();
    }

    private void StartHover(HoverEnterEventArgs args)
    {
        meshRenderer.material = hoverMaterial;

        if (onButtonPress != null)
        {
            onButtonPress(buttonNumber);
        }
    }

    private void EndHover(HoverExitEventArgs args)
    {
        meshRenderer.material = nonHoverMaterial;
    }
}
