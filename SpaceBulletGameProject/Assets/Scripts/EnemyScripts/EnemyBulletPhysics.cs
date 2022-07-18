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

    private void Start()
    {
        isHit = false;
        isHitPlayer = false;

        target = playerShip.position * 2;
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
        }

        if (collision.gameObject.tag == "Obstacle")
        {
            isHit = true;
        }
    }
}
