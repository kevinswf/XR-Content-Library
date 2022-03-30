using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceSound : MonoBehaviour
{
    private AudioSource audioSource;
    private Rigidbody rb;
    
    [SerializeField]
    private AudioClip bounceAudio;
    [SerializeField]
    private float maxVolume = 20.0f;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        // use velocity as the volume for now (could probably write a transfer function between velocity and volume later)
        float volume = rb.velocity.magnitude;
        if(volume > maxVolume)
            volume = maxVolume;
        audioSource.PlayOneShot(bounceAudio, volume / maxVolume);
    }
}
