using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    [Header("Player Ship")]
    [SerializeField] private Animator playerShip;

    [Header("Player Ship's Animator")]
    [SerializeField] private Animator playerShipAnimator;

    [Header("Player Ship's Sight")]
    [SerializeField] private GameObject sight;

    [Header("Enemy Ship Counter")]
    [SerializeField] private int enemyShipCount;

    [Header("Complete Panel")]
    [SerializeField] private GameObject complete;
    [SerializeField] private float completePanelTime;

    [Header("Managers")]
    [SerializeField] private GameObject unlockOrLockedLevels;

    private void Start()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("ContinueLevel", sceneIndex);
    }

    private void PlayerShipAdvance()
    {
        playerShipAnimator.SetTrigger("Advance");
        StartCoroutine(ActivateComplete());
    }

    private IEnumerator ActivateComplete()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (sceneIndex == 16)
            PlayerPrefs.SetInt("ContinueLevel", 16);
        else
            PlayerPrefs.SetInt("ContinueLevel", sceneIndex + 1);
        unlockOrLockedLevels.GetComponent<UnlockOrLockedLevels>().CompleteLevel(sceneIndex);

        yield return new WaitForSeconds(completePanelTime);

        complete.SetActive(true);
    }

    private void EnemyShipCountChecker()
    {
        if (enemyShipCount == 0)
        {
            PlayerShipAdvance();
        }
    }

    public void DestroyedOneEnemyShip()
    {
        enemyShipCount = enemyShipCount - 1;
        EnemyShipCountChecker();
    }

    public int GetEnemyShipCount()
    {
        return enemyShipCount;
    }
}
