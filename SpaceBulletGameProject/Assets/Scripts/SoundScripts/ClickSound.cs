using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickSound : MonoBehaviour
{
    private AudioSource myAudioSource;

    private void Awake()
    {
        myAudioSource = this.GetComponent<AudioSource>();
    }

    public void ActivateSound()
    {
        myAudioSource.enabled = false;
        myAudioSource.enabled = true;
    }
}
