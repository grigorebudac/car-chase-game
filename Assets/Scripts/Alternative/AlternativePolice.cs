using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlternativePolice : MonoBehaviour
{
    private GameObject target;

    private Rigidbody myBody;
    [SerializeField]
    private float speed = 40f, rotatingSpeed = 20f;
    Vector3 pointToTarget;

    void Start()
    {
        myBody = GetComponent<Rigidbody>();
        target = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (target)
        {
            pointToTarget = transform.position - target.transform.position;
        }
        pointToTarget.Normalize();

        float value = Vector3.Cross(pointToTarget, transform.forward).y;

        myBody.angularVelocity = rotatingSpeed * value * Vector3.up;
        myBody.velocity = transform.forward * speed;
    }
}

