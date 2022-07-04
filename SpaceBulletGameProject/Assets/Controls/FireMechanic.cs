using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireMechanic : MonoBehaviour
{
    [Header("Player Ship")]
    [SerializeField] private GameObject sight;
    [SerializeField] private Transform gun;
    
    [Header("Bullet Prefab")]
    [SerializeField] private GameObject bullet;
    private GameObject bulletClone;
    [HideInInspector] public bool isFireBullet;

    [Header("Magazine")]
    [SerializeField] private GameObject[] bulletsInsideMagazine;
    private int bulletNumber;
    [HideInInspector] public bool isMagazineEmpty;

    private void Start()
    {
        bulletNumber = 0;
        bulletClone = null;
    }

    private void Update()
    {
        FireMechanicManager();
    }

    private void FireMechanicManager()
    {
        Fire();
        DestroyBullet();
    }

    private void Fire()
    {
        if (isFireBullet)
            return;

        if (isMagazineEmpty)
            return;

        if (Input.GetMouseButtonDown(0))
        {
            FireBullet();
        }
    }

    private void FireBullet()
    {
        bulletClone = Instantiate(bullet, gun.transform.position, sight.transform.rotation);

        isFireBullet = true;
        sight.GetComponent<SightMoving>().stopRotation = true;
    }

    private void DestroyBullet()
    {
        if (!isFireBullet)
            return;

        if (bulletClone.GetComponent<BulletPhysics>().isHit)
        {
            isFireBullet = false;
            sight.GetComponent<SightMoving>().stopRotation = false;
            Magazine();
            Destroy(bulletClone);
        }
    }

    private void Magazine()
    {
        bulletsInsideMagazine[bulletNumber].SetActive(false);
        bulletNumber = bulletNumber + 1; // 1 bullet is used.
        if (bulletNumber == bulletsInsideMagazine.Length)
        {
            isMagazineEmpty = true;
        }
    }
}
