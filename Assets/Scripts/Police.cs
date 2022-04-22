using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Police : MonoBehaviour
{
    private GameObject target;

    private Rigidbody myBody;
    [SerializeField]
    private float speed = 60f, rotatingSpeed = 20f;

    // Start is called before the first frame update
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

    // IEnumerator UpdatePath()
    // {
    //     float refreshRate = 0.25f;

    //     while (target != null)
    //     {
    //         Vector3 targetPosition = new Vector3(target.position.x, 0, target.position.z);
    //         pathFinder.SetDestination(targetPosition);
    //         yield return new WaitForSeconds(refreshRate);
    //     }
    // }
}
