using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayQuickSound : MonoBehaviour
{
    [SerializeField]
    private AudioClip audioClip = null;
    [SerializeField]
    private float volume = 1.0f;

    private AudioSource audioSource = null;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound()
    {
        audioSource.PlayOneShot(audioClip, volume);
    }
}
