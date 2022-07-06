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
        if (playerShip.GetComponent<FireMechanic>().isMagazineEmpty)
        {
            StartCoroutine(Fire());
            flag = false;
        }
    }
    private IEnumerator Fire()
    {
        yield return new WaitForSeconds(2.5f);
        FireBullet();
    }

    private void FireBullet()
    {
        enemyBulletClone = Instantiate(enemyBullet, gun.transform.position, enemyBullet.transform.rotation);
        RotateTowardsTarget();
        isFireBullet = true;
    }

    private void DestroyBullet()
    {
        if (!isFireBullet)
            return;

        if (enemyBulletClone.GetComponent<EnemyBulletPhysics>().isHit)
        {
            isFireBullet = false;
            Destroy(enemyBulletClone);
        }
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
