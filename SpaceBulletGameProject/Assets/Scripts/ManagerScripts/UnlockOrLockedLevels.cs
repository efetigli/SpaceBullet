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

    [SerializeField] private float delayTime;

    //private void Awake()
    //{
    //    CompleteLevel(1);
    //}

    public void CompleteLevel(int levelIndex)
    {
        string levelName = "Level" + levelIndex.ToString();
        PlayerPrefs.SetInt(levelName, 1);
    }

    public void ClickContinueLevelButton()
    {
        StartCoroutine(DelayChangeSceneContinue());
    }
    private IEnumerator DelayChangeSceneContinue()
    {
        yield return new WaitForSeconds(delayTime);
        //SceneManager.LoadScene(PlayerPrefs.GetInt("ContinueLevel"));
        StartCoroutine(ContinueAsyncScene());
    }

    public void DeleteLevelsData()
    {
        float masterVolume = PlayerPrefs.GetFloat("MasterVolume");
        float musicVolume = PlayerPrefs.GetFloat("MusicVolume");
        float sfxVolume = PlayerPrefs.GetFloat("SFXVolume");
        int mute = PlayerPrefs.GetInt("Mute");
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetFloat("MasterVolume", masterVolume);
        PlayerPrefs.SetFloat("MusicVolume", musicVolume);
        PlayerPrefs.SetFloat("SFXVolume", sfxVolume);
        PlayerPrefs.SetInt("Mute", mute);
    }

    public void AdminDeleteLevelsData()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("MainMenu");
    }

    IEnumerator ContinueAsyncScene()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(PlayerPrefs.GetInt("ContinueLevel"));
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
