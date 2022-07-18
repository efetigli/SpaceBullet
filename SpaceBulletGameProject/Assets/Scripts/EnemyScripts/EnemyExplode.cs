using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyExplode : MonoBehaviour
{
    [SerializeField] private GameObject enemyExplosion;
    [SerializeField] private float explosionTime;

    [SerializeField] private GameObject enemySprite;

    public void ExplodeEnemyShip()
    {
        StartCoroutine(EnemyShipExplodeAnimation());
    }

    private IEnumerator EnemyShipExplodeAnimation()
    {
        enemyExplosion.SetActive(true);

        enemySprite.SetActive(false);
        yield return new WaitForSeconds(explosionTime);
        Destroy(this.gameObject);
    }

}
