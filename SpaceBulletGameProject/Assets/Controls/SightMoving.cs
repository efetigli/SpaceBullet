using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SightMoving : MonoBehaviour
{
    [SerializeField] private float range;
    [SerializeField] private float rotateSpeed;

    private Vector3 leftRotate;
    private Vector3 rightRotate;

    private bool isRotatingLeft;

    [HideInInspector] public bool stopRotation;

    [HideInInspector] public bool moveOriginalRotation;
    [HideInInspector] public bool isReachedOriginalRotation;

    private void Start()
    {
        leftRotate = new Vector3(0, 0, 1);
        rightRotate = new Vector3(0, 0, -1);

        isRotatingLeft = true;
    }

    private void Update()
    {
        RotateManager();
    }

    // Using "RotateSight" and "Flip" methods to rotate the sight.
    private void RotateManager()
    {
        if (stopRotation)
            return;

        Flip();

        if (isRotatingLeft)
            RotateSight(leftRotate);
        else if (!isRotatingLeft)
            RotateSight(rightRotate);
        
    }

    // Rotates the sight. Takes parameter "side" which represents which side of sight should move. Left or Right.
    private void RotateSight(Vector3 side)
    {
        transform.Rotate(side * rotateSpeed * Time.deltaTime);
    }

    // If the sight reach the range, change the moving direction of the sight.
    private void Flip()
    {
        bool isFlip = !( this.transform.localEulerAngles.z <= range || 
            this.transform.localEulerAngles.z >= (360 - range) );
        if (isFlip)
            isRotatingLeft = !isRotatingLeft;

        ReachOriginalRotation();
    }

    private void ReachOriginalRotation()
    {
        if (!moveOriginalRotation)
            return;

        Debug.Log(this.transform.rotation.z);

        Vector3 originalRotation = new Vector3(0, 0, 0);

        if(Vector3.Distance(transform.eulerAngles, originalRotation) > 0.01f)
        {
            transform.eulerAngles = originalRotation;
            stopRotation = true;
            isReachedOriginalRotation = true;
        }
    }
}
