using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitiatNarrator : MonoBehaviour
{
    //Location of this may be changed as it's on testing level.
    AudioSource aud;

    // Start is called before the first frame update
    void Start()
    {
        aud = GetComponent<AudioSource>();
        aud.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
