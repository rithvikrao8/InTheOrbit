using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMusicOnDistance : MonoBehaviour
{
    public Transform targetObject;  // The object to check the distance from
    public float distanceThreshold = 10f;  // Distance within which the music should start playing
    public AudioClip musicClip;  // The music clip to play
    private AudioSource audioSource;  // The AudioSource component
    
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (musicClip != null)
        {
            audioSource.clip = musicClip;
        }
    }

    void Update()
    {
    
        float distance = Vector3.Distance(transform.position, targetObject.position);

        if (distance <= distanceThreshold && !audioSource.isPlaying)
        {
            audioSource.Play();
        }
        else if (distance > distanceThreshold && audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    
    }
}

