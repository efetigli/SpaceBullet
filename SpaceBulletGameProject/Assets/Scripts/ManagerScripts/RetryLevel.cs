using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryLevel : MonoBehaviour
{
    public void ClickRetryLevelButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
