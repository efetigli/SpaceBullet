using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPhysics : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [HideInInspector] public bool isHit;

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
        this.transform.position += transform.up * moveSpeed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
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
