using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletPhysics : MonoBehaviour
{
    [SerializeField] private Transform playerShip;
    [SerializeField] private float moveSpeed;
    [HideInInspector] public bool isHit;
    [HideInInspector] public bool isHitPlayer;
    private Vector3 target;

    [SerializeField] private GameObject bulletFire;

    private void Start()
    {
        isHit = false;
        isHitPlayer = false;

        float x_difference = playerShip.position.x - this.transform.position.x;
        float y_difference = playerShip.position.y - this.transform.position.y;

        target = new Vector3(playerShip.position.x + x_difference,
            playerShip.position.y + y_difference,
            playerShip.position.z);
    }

    void Update()
    {
        BulletMove();
    }

    private void BulletMove()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isHit = true;
            isHitPlayer = true;
            //Destroy(collision.gameObject.transform.parent.gameObject);
            GameObject playerShip = collision.gameObject.transform.parent.gameObject;
            playerShip.GetComponent<PlayerExplode>().ExplodePlayerShip();
            DisableBulletFire();
        }

        if (collision.gameObject.tag == "Obstacle")
        {
            isHit = true;
            DisableBulletFire();
        }
    }

    private void DisableBulletFire()
    {
        bulletFire.SetActive(false);
    }
}
