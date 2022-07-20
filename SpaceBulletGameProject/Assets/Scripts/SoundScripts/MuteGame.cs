using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuteGame : MonoBehaviour
{
    private bool isMute;

    private void Start()
    {
        SavedMute();
    }

    private void SavedMute()
    {
        int m = PlayerPrefs.GetInt("Mute");
        if (m == 1)
        {
            isMute = true;
            AudioListener.volume = 0;
            this.GetComponent<Image>().color = Color.red;
        }
        else if (m == 0)
        {
            isMute = false;
            AudioListener.volume = 1;
            this.GetComponent<Image>().color = Color.white;
        }
    }

    public void MuteOrUnmuteGame()
    {
        if (isMute)
        {
            isMute = false;
            AudioListener.volume = 1;
            PlayerPrefs.SetInt("Mute", 0);
            this.GetComponent<Image>().color = Color.white;
        }
        else if (!isMute)
        {
            isMute = true;
            AudioListener.volume = 0;
            PlayerPrefs.SetInt("Mute", 1);
            this.GetComponent<Image>().color = Color.red;
        }
    }
}
