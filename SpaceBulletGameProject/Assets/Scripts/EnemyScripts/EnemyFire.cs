using System.Collections;
using UnityEngine;

public class EnemyFire : MonoBehaviour
{
    [SerializeField] private Transform gun;

    [SerializeField] private GameObject playerShip;

    [HideInInspector] public bool isFireBullet;

    [SerializeField] private GameObject enemyBullet;

    private GameObject enemyBulletClone;

    private bool flag;

    [SerializeField] private GameObject gameOver;

    [Header("Needed Managers")]
    [SerializeField] private GameObject levelManager;

    [Header("Fire Sound")]
    [SerializeField] private AudioSource enemyFireSfx;

    private void Start()
    {
        flag = true;
        enemyBulletClone = null;
    }

    public void Update()
    {
        FireManager();
    }

    private void FireManager()
    {
        KillPlayerShip();
        DestroyBullet();
    }

    private void KillPlayerShip()
    {
        if (!flag)
            return;
        if (playerShip.GetComponent<FireMechanic>().isMagazineEmpty 
            && levelManager.GetComponent<LevelManager>().GetEnemyShipCount() != 0)
        {
            StartCoroutine(Fire());
            flag = false;
        }
    }
    private IEnumerator Fire()
    {
        yield return new WaitForSeconds(1.5f);
        FireBullet();
    }

    private void FireBullet()
    {
        enemyFireSfx.enabled = false;
        enemyBulletClone = Instantiate(enemyBullet, gun.transform.position, enemyBullet.transform.rotation);
        enemyFireSfx.enabled = true;
        RotateTowardsTarget();
        isFireBullet = true;
    }

    private void DestroyBullet()
    {
        if (!isFireBullet)
            return;

        if (enemyBulletClone.GetComponent<EnemyBulletPhysics>().isHit)
        {
            if (enemyBulletClone.GetComponent<EnemyBulletPhysics>().isHitPlayer)
                StartCoroutine(ActivateGameOver());
            isFireBullet = false;
            Destroy(enemyBulletClone);
        }
    }

    private IEnumerator ActivateGameOver()
    {
        yield return new WaitForSeconds(1f);
        
        gameOver.SetActive(true);
    }

    private void RotateTowardsTarget()
    {
        var offset = 90f;
        Vector2 direction = playerShip.transform.position - enemyBulletClone.transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        enemyBulletClone.transform.rotation = Quaternion.Euler(Vector3.forward * (angle + offset));
    }
}
