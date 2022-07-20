using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private string exposedParamaterName;

    [SerializeField] private Slider mySlider;

    private bool isMute;

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat(exposedParamaterName, volume);
        PlayerPrefs.SetFloat(exposedParamaterName, volume);
    }

}
