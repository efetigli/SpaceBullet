using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireMechanic : MonoBehaviour
{
    [SerializeField] private GameObject sight;
    [SerializeField] private Transform gun;
    [SerializeField] private GameObject bullet;

    private GameObject bulletClone;

    [HideInInspector] public bool isFireBullet;

    private void Start()
    {
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
            Destroy(bulletClone);
        }
    }
}
