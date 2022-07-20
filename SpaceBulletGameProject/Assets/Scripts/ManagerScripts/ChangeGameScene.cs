using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeGameScene : MonoBehaviour
{
    [SerializeField] private string sceneName;
    [SerializeField] private float delayTime;

    public void ClickChangeGameScene()
    {
        StartCoroutine(DelayChangeScene());
    }

    private IEnumerator DelayChangeScene()
    {
        yield return new WaitForSecondsRealtime(delayTime);
        Time.timeScale = 1;
        SceneManager.LoadScene(sceneName);
    }
}
