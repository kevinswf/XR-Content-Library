using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleMagGlassMaterial : MonoBehaviour
{
    [SerializeField]
    private Material magnifyingMaterial = null;

    private MeshRenderer meshRenderer = null;
    private Material offMaterial = null;

    void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        offMaterial = meshRenderer.material;
    }

    public void SetMagMaterial()
    {
        meshRenderer.material = magnifyingMaterial;
    }

    public void SetOffMaterial()
    {
        meshRenderer.material = offMaterial;
    }
}
