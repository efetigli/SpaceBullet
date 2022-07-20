using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLateralMovement : MonoBehaviour
{
    [Header("Waypoints")]
    [SerializeField] private Transform leftLimit;
    [SerializeField] private Transform rightLimit;
    private float distanceBetweenLimits;
    private bool isMovingLeft;
    private bool isMovingRight;

    [Header("Flying Attribute")]
    [SerializeField] private float speed;
    private float distanceBetweenShipAndLimit;

    private float waitTime = 2f;
    private bool isAbleToMoveLateral = false;

    private void Start()
    {
        isMovingRight = true;
        isMovingLeft = false;
        distanceBetweenLimits = Mathf.Abs(leftLimit.position.x - rightLimit.position.x);
        StartCoroutine(AbleToMoveLateral());
    }

    private void Update()
    {
        Lateral();
    }

    private void Lateral()
    {
        if (!isAbleToMoveLateral)
            return;

        if (isMovingLeft)
        {
            distanceBetweenShipAndLimit = Mathf.Abs(this.transform.position.x - rightLimit.transform.position.x);
            if (distanceBetweenShipAndLimit >= distanceBetweenLimits)
            {
                isMovingRight = true;
                isMovingLeft = false;
                return;
            }

            transform.position = transform.position + new Vector3(-speed * Time.deltaTime, 0, 0);
        }
        else if (isMovingRight)
        {
            distanceBetweenShipAndLimit = Mathf.Abs(this.transform.position.x - leftLimit.transform.position.x);
            if (distanceBetweenShipAndLimit >= distanceBetweenLimits)
            {
                isMovingRight = false;
                isMovingLeft = true;
                return;
            }

            transform.position = transform.position + new Vector3(speed * Time.deltaTime, 0, 0);
        }
    }

    private IEnumerator AbleToMoveLateral()
    {
        yield return new WaitForSecondsRealtime(waitTime);
        isAbleToMoveLateral = true;
    }

}
