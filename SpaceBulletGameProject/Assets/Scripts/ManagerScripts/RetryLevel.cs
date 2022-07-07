using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryLevel : MonoBehaviour
{
    [SerializeField] private float delayTime;

    public void ClickRetryLevelButton()
    {
        StartCoroutine(DelayChangeScene());
    }

    private IEnumerator DelayChangeScene()
    {
        yield return new WaitForSeconds(delayTime);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
