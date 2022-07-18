using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShipHitPlayerShip : MonoBehaviour
{
    [Header("Game Over")]
    [SerializeField] private GameObject gameOver;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            gameOver.SetActive(true);
            //Destroy(collision.gameObject.transform.parent.gameObject);
            GameObject playerShip = collision.gameObject.transform.parent.gameObject;
            playerShip.GetComponent<PlayerExplode>().ExplodePlayerShip();
        }
    }
}
