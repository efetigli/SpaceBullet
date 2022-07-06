using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelsMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject[] LevelButtons;
    [SerializeField] private GameObject continueButton;

    void Start()
    {
        for (int i = 0; i < LevelButtons.Length; i++)
        {
            int index = i + 1;
            string levelName = "Level" + index.ToString();
            if(PlayerPrefs.GetInt(levelName) >= 1)
            {
                LevelButtons[i].SetActive(true);
            }
            
        }

        if(PlayerPrefs.GetInt("ContinueLevel") != 0)
        {
            continueButton.GetComponent<Button>().enabled = true;
            var tempColor = continueButton.GetComponent<Image>().color;
            tempColor.a = 1f;
            continueButton.GetComponent<Image>().color = tempColor;
        }
    }

    
}
