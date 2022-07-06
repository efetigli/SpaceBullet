using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UnlockOrLockedLevels : MonoBehaviour
{
    int Level1;
    int Level2;
    int Level3;
    int Level4;
    int Level5;
    int Level6;
    int Level7;
    int Level8;
    int Level9;
    int Level10;
    int Level11;
    int Level12;
    int Level13;
    int Level14;
    int Level15;
    int Level16;

    int ContinueLevel;

    private void Awake()
    {
        CompleteLevel(1);
    }

    public void CompleteLevel(int levelIndex)
    {
        string levelName = "Level" + levelIndex.ToString();
        PlayerPrefs.SetInt(levelName, 1);
    }

    public void ClickContinueLevelButton()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("ContinueLevel"));
    }

    public void DeleteLevelsData()
    {
        PlayerPrefs.DeleteAll();
    }
}
