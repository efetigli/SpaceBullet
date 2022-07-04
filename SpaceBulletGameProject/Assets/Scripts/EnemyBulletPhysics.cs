using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletPhysics : MonoBehaviour
{
    [SerializeField] private Transform playerShip;
    [SerializeField] private float moveSpeed;
     public bool isHit;

    private void Start()
    {
        isHit = false;
    }

    void Update()
    {
        BulletMove();
    }

    private void BulletMove()
    {
        transform.position = Vector3.MoveTowards(transform.position, playerShip.position, moveSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isHit = true;
            Destroy(collision.gameObject.transform.parent.gameObject);
        }

        if (collision.gameObject.tag == "Obstacle")
        {
            isHit = true;
        }
    }
}
