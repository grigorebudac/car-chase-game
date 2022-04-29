using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Police : MonoBehaviour
{
    private NavMeshAgent pathFinder;
    Transform target;

    void Start()
    {
        pathFinder = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player").transform;

        StartCoroutine(UpdatePath());
    }

    IEnumerator UpdatePath()
    {
        float refreshRate = 0.25f;

        while (target != null)
        {
            Vector3 targetPosition = new Vector3(target.position.x, 0, target.position.z);
            pathFinder.SetDestination(targetPosition);
            yield return new WaitForSeconds(refreshRate);
        }
    }
}