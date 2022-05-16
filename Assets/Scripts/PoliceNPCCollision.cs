using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PoliceNPCCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        HealthController ownHealthController = gameObject.GetComponent<NPCController>().carHealth;
        float damageToTake = 50f;
        ownHealthController.TakeDamage(damageToTake);
    }

    public void OnTriggerEnter(Collider other)
    {

    }
}
