using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerExplode : MonoBehaviour
{
    [SerializeField] private GameObject playerExplosion;
    [SerializeField] private float explosionTime;

    [SerializeField] private GameObject playerSprite;
    [SerializeField] private GameObject playerSight;

    public void ExplodePlayerShip()
    {
        StartCoroutine(PlayerShipExplodeAnimation());
    }

    private IEnumerator PlayerShipExplodeAnimation()
    {
        playerExplosion.SetActive(true);

        playerSprite.SetActive(false);
        playerSight.SetActive(false);
        yield return new WaitForSeconds(explosionTime);
        Destroy(this.gameObject);
    }
}
