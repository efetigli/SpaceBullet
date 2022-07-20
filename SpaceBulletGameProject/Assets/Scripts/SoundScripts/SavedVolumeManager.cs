using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SavedVolumeManager : MonoBehaviour
{
    [Header("Slider Name")]
    [SerializeField] private Slider masterSlider;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;

    [Header("Toggle")]
    [SerializeField] private Toggle muteToggle;

    [Header("Exposed Paramater Names")]
    [SerializeField] private string masterParamaterName;
    [SerializeField] private string musicParamaterName;
    [SerializeField] private string sfxParamaterName;

    [Header("Auido Mixer")]
    [SerializeField] private AudioMixer myAudioMixer;


    private void Start()
    {
        SavedMute();
        SetAsSaveVolume(masterSlider, masterParamaterName);
        SetAsSaveVolume(musicSlider, musicParamaterName);
        SetAsSaveVolume(sfxSlider, sfxParamaterName);
    }

    public void SetAsSaveVolume(Slider mySlider,string exposedParamaterName)
    {
        mySlider.value = PlayerPrefs.GetFloat(exposedParamaterName);
        myAudioMixer.SetFloat(exposedParamaterName, PlayerPrefs.GetFloat(exposedParamaterName));
    }

    private void SavedMute()
    {
        int m = PlayerPrefs.GetInt("Mute");
        if (m == 1)
        {
            AudioListener.volume = 0;
            muteToggle.isOn = false;
        }
        else if (m == 0)
        {
            AudioListener.volume = 1;
            muteToggle.isOn = true;
        }
    }

}
