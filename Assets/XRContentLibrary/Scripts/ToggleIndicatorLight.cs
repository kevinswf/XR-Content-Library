using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleIndicatorLight : MonoBehaviour
{
    [SerializeField]
    private Material onLight = null;

    private bool on = false;
    private MeshRenderer meshRenderer = null;
    private Material offLight = null;

    void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        offLight = meshRenderer.material;
    }

    public void ToggleLight()
    {
        on = !on;
        if(on)
            meshRenderer.material = onLight;
        else
            meshRenderer.material = offLight;
    }
}
