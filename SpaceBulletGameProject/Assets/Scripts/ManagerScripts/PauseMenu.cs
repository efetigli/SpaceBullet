using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [Header("Pause Menu")]
    [SerializeField] private GameObject pauseMenu;

    public void ClickPauseButton()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
    }

    public void ClickContinueButton()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }

    //public void ClickSomethingChangesSceneButton()
    //{
    //    Time.timeScale = 1;
    //}
}
