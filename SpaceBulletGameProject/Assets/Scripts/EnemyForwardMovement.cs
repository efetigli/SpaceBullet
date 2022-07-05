using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyForwardMovement : MonoBehaviour
{
    [Header("Flying Attribute")]
    [SerializeField] private float speed;


    private void Update()
    {
        Forward();
    }

    private void Forward()
    {
        transform.position = transform.position + new Vector3(0, -speed * Time.deltaTime, 0);
    }
}
