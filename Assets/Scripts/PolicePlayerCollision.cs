using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PolicePlayerCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        PrometeoCarController car = gameObject.GetComponent<PrometeoCarController>();
        HealthController ownHealthController = gameObject.GetComponent<PlayerController>().carHealth;

        float damageTaken = 0;
        float damageToTake = 100f;

        switch (collision.gameObject.tag)
        {
            case "Wall":
                damageToTake = car ? car.carSpeed : 200f;
                damageTaken = this.GetHitByWallDamage(damageToTake);
                break;
            case "Player":
                damageToTake = car ? car.carSpeed : 200f;
                damageTaken = this.GetHitByPoliceCarDamage(damageToTake);
                break;
            default:
                break;
        }

        ownHealthController.TakeDamage(damageTaken);
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

    private float GetHitByWallDamage(float carSpeed)
    {
        float damage = carSpeed / 10f;
        return Math.Abs(damage);
    }

    private float GetHitByPoliceCarDamage(float policeCarSpeed)
    {
        float damage = policeCarSpeed / 5f;
        return Math.Abs(damage);
    }
}
