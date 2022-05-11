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
        // Debug.Log("trigger" + other.gameObject.name);
        // if (other.gameObject.tag == "Wall")
        // {
        //     HealthController ownHealthController = gameObject.GetComponent<PlayerController>() != null ? gameObject.GetComponent<PlayerController>().carHealth : gameObject.GetComponent<NPCController>().carHealth;
        //     // HealthController otherHealthController = collision.gameObject.GetComponent<HealthController>();
        //     float damageTaken = 0;
        //     damageTaken = this.GetHitByWallDamage(200f);
        //     ownHealthController.TakeDamage(damageTaken);
        // }
    }
}
