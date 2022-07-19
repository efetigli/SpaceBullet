using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyExplode : MonoBehaviour
{
    [SerializeField] private GameObject enemyExplosion;
    [SerializeField] private float explosionTime;

    [SerializeField] private GameObject enemySprite;

    [SerializeField] private AudioSource enemyExplodeSfx;

    public void ExplodeEnemyShip()
    {
        StartCoroutine(EnemyShipExplodeAnimation());
    }

    private IEnumerator EnemyShipExplodeAnimation()
    {
        enemyExplodeSfx.enabled = false;

        enemyExplosion.SetActive(true);

        enemySprite.SetActive(false);

        this.GetComponent<EnemyLateralMovement>().enabled = false;
        this.GetComponent<EnemyForwardMovement>().enabled = false;

        enemyExplodeSfx.enabled = true;

        yield return new WaitForSeconds(explosionTime);
        Destroy(this.gameObject);
    }

}
