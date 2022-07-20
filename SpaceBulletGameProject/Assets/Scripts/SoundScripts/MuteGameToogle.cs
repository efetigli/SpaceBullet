using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuteGameToogle : MonoBehaviour
{
    private bool isMute;

    public void MuteOrUnmuteGame()
    {
        if (isMute)
        {
            isMute = false;
            AudioListener.volume = 1;
            PlayerPrefs.SetInt("Mute", 0);
            this.GetComponent<Toggle>().isOn = true;
        }
        else if (!isMute)
        {
            isMute = true;
            AudioListener.volume = 0;
            PlayerPrefs.SetInt("Mute", 1);
            this.GetComponent<Toggle>().isOn = false;
        }
    }
}
