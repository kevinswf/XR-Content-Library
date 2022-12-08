using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ApplyPhysics))]
public class Photo : MonoBehaviour
{
    [SerializeField]
    private MeshRenderer photoRenderer = null;
    private Collider mCollider = null;
    private ApplyPhysics applyPhysics = null;

    void Awake()
    {
        mCollider = GetComponent<Collider>();
        applyPhysics = GetComponent<ApplyPhysics>();
    }
    // Start is called before the first frame update
    void Start()
    {
        // print the photo over some time
        StartCoroutine(PrintPhoto(1.5f));
    }

    public IEnumerator PrintPhoto(float seconds)
    {
        // disable physics when printing, and use kinematics
        applyPhysics.DisablePhysics();
        mCollider.enabled = false;

        float elapsedTime = 0;
        while (elapsedTime < seconds)
        {
            transform.position += transform.forward * Time.deltaTime * 0.1f;
            elapsedTime += Time.deltaTime;

            yield return null;
        }

        mCollider.enabled = true;
    }

    public void SetPhoto(Texture2D texture)
    {
        photoRenderer.material.color = Color.white;
        photoRenderer.material.mainTexture = texture;
    }
}
