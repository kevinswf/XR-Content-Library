using UnityEngine;
using UnityEngine.Video;

[RequireComponent(typeof(VideoPlayer))]
public class PlayVideo : MonoBehaviour
{
    [SerializeField]
    private bool playAtStart = false;
    [SerializeField]
    private VideoClip videoClip = null;

    private VideoPlayer videoPlayer = null;
    private MeshRenderer meshRenderer = null;

    private Material offMaterial = null;
    private Material videoMaterial = null;

    private readonly string shaderUsed = "Universal Render Pipeline/Unlit";

    void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        videoPlayer = GetComponent<VideoPlayer>();

        videoPlayer.clip = videoClip;
        offMaterial = meshRenderer.material;

        // create the material for playing video
        videoMaterial = new Material(Shader.Find(shaderUsed));
        videoMaterial.color = Color.white;
    }

    void Start()
    {
        if(playAtStart)
            Play();
        else
            Stop();
    }

    private void Play()
    {
        meshRenderer.material = videoMaterial;
        videoPlayer.Play();
    }

    private void Stop()
    {
        meshRenderer.material = offMaterial;
        videoPlayer.Stop();
    }

    public void TogglePlayStop()
    {
        bool isPlaying = videoPlayer.isPlaying;
        if(!isPlaying)
            Play();
        else
            Stop();
    }

    void OnValidate()
    {
        if (TryGetComponent(out VideoPlayer videoPlayer))
            videoPlayer.targetMaterialProperty = "_BaseMap";
    }
}
