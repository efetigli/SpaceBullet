using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelScene : MonoBehaviour
{
    [SerializeField] private float delayTime;

    public void ClickNextLevelSceneButton()
    {
        StartCoroutine(DelayChangeScene());
    }

    private IEnumerator DelayChangeScene()
    {
        yield return new WaitForSeconds(delayTime);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
