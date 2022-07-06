using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeGameScene : MonoBehaviour
{
    [SerializeField] private string sceneName;

    public void ClickChangeGameScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
