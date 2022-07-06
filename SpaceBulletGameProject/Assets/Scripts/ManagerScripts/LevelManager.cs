using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private void PlayerShipAdvance()
    {
        playerShipAnimator.SetTrigger("Advance");
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
}
