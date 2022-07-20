using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyForwardMovement : MonoBehaviour
{
    [Header("Flying Attribute")]
    [SerializeField] private float speed;

    private float waitTime = 2f;
    private bool isAbleToMoveForward = false;

    private void Start()
    {
        StartCoroutine(AbleToMoveForward());
    }

    private void Update()
    {
        Forward();
    }

    private void Forward()
    {
        if (!isAbleToMoveForward)
            return;

        transform.position = transform.position + new Vector3(0, -speed * Time.deltaTime, 0);
    }

    private IEnumerator AbleToMoveForward()
    {
        yield return new WaitForSecondsRealtime(waitTime);
        isAbleToMoveForward = true;
    }
}
