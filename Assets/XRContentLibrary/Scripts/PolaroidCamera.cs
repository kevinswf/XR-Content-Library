using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolaroidCamera : MonoBehaviour
{
    [SerializeField]
    private GameObject photoPrefab = null;
    [SerializeField]
    private MeshRenderer screenRenderer = null;
    [SerializeField]
    private Transform photoSpawnLocation = null;

    private Camera renderCamera;

    void Awake()
    {
        // get the camera component
        renderCamera = GetComponentInChildren<Camera>();
    }

    // Start is called before the first frame update
    void Start()
    {
        // create and bind render texture for the camera viewfinder-
        CreateRenderTexture();

        TurnOff();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void CreateRenderTexture()
    {
        // create the render texture for the camera viewfinder
        RenderTexture renderTexture = new RenderTexture(256, 256, 32, RenderTextureFormat.Default, RenderTextureReadWrite.sRGB);
        renderTexture.antiAliasing = 4;

        // camera renders to the render texture
        renderCamera.targetTexture = renderTexture;

        // the viewfinder material uses the render texture
        screenRenderer.material.mainTexture = renderTexture;
    }

    public void TurnOn()
    {
        renderCamera.enabled = true;
        screenRenderer.material.color = Color.white;
    }

    public void TurnOff()
    {
        renderCamera.enabled = false;
        screenRenderer.material.color = Color.black;
    }

    public void TakePhoto()
    {
        Photo newPhoto = CreatePhoto();
        RenderPhoto(newPhoto);
    }

    private Photo CreatePhoto()
    {
        // instantiate a photo object prefab
        GameObject photoObject = Instantiate(photoPrefab, photoSpawnLocation.position, photoSpawnLocation.rotation, transform);
        return photoObject.GetComponent<Photo>();
    }

    private void RenderPhoto(Photo photo)
    {
        // render a texture from the camera, then set texture on to photo
        Texture2D newTexture = RenderCameraToTexture(renderCamera);
        photo.SetPhoto(newTexture);
    }

    private Texture2D RenderCameraToTexture(Camera camera)
    {
        camera.Render();
        RenderTexture.active = camera.targetTexture;

        Texture2D photoTexture = new Texture2D(256, 256, TextureFormat.RGB24, false);
        photoTexture.ReadPixels(new Rect(0, 0, 256, 256), 0, 0);
        photoTexture.Apply();

        return photoTexture;
    }
}
