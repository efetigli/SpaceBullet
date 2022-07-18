using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPhysics : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [HideInInspector] public bool isHit;
    [HideInInspector] public bool isHitEnemyShip;


    [Header("Explode")]
    [SerializeField] private GameObject bulletExplosion;
    [SerializeField] private float explosionTime;
    [SerializeField] private GameObject bulletSprite;
    [SerializeField] private GameObject bulletFire;
    private bool stopPlayerBullet;

    private void Start()
    {
        isHit = false;
        isHitEnemyShip = false;
    }

    void Update()
    {
        BulletMove();
    }

    private void BulletMove()
    {
        if (stopPlayerBullet) { return; }

        this.transform.position += transform.up * moveSpeed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            isHit = true;
            isHitEnemyShip = true;
            //Destroy(collision.gameObject.transform.parent.gameObject);
            GameObject enemyShip = collision.gameObject.transform.parent.gameObject;
            enemyShip.GetComponent<EnemyExplode>().ExplodeEnemyShip();
            enemyShip.GetComponent<EnemyFire>().enabled = false;
        }

        if (collision.gameObject.tag == "Obstacle")
        {
            isHit = true;
        }
    }

    public void ExplodePlayerBullet()
    {
        if (isHitEnemyShip)
        {
            Destroy(this.gameObject);
            return;
        }
        StartCoroutine(PlayerBulletExplodeAnimation());
    }

    private IEnumerator PlayerBulletExplodeAnimation()
    {
        stopPlayerBullet = true;
        bulletExplosion.SetActive(true);
        bulletSprite.SetActive(false);
        bulletFire.SetActive(false);

        this.GetComponent<CapsuleCollider2D>().enabled = false;

        yield return new WaitForSeconds(explosionTime);
        Destroy(this.gameObject);
    }

}
