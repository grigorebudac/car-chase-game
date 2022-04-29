using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlternativePolice : MonoBehaviour
{
    private GameObject target;

    private Rigidbody myBody;
    [SerializeField]
    private float speed = 60f, rotatingSpeed = 20f;

    void Start()
    {
        myBody = GetComponent<Rigidbody>();
        target = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        Vector3 pointToTarget = transform.position - target.transform.position;
        pointToTarget.Normalize();

        float value = Vector3.Cross(pointToTarget, transform.forward).y;

        myBody.angularVelocity = rotatingSpeed * value * Vector3.up;
        myBody.velocity = transform.forward * speed;
    }
}

