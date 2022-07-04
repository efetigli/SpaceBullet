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
        this.transform.position += transform.up * moveSpeed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isHit = true;
    }
}
