using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField]
    private AudioSource hitSound;

    private void OnCollisionEnter(Collision collision)
    {
        
        PrometeoCarController car = gameObject.GetComponent<PrometeoCarController>();
        HealthController ownHealthController = gameObject.GetComponent<PlayerController>().carHealth;

        if (gameObject.GetComponent<PlayerController>().isUsingShield)
        {
            return;
        }
        
        float damageTaken = 0;
        float damageToTake = 100f;

        switch (collision.gameObject.tag)
        {
            case "Building":
                damageToTake = car ? car.carSpeed : 200f;
                damageTaken = this.GetHitByWallDamage(damageToTake);
                
                if (hitSound != null)
                {
                    hitSound.Play();
                }
                break;
            case "PoliceNPC":
                break;
            case "PolicePlayer":
                damageToTake = 100f;
                damageTaken = this.GetHitByPoliceCarDamage(damageToTake);
                
                if (hitSound != null)
                {
                    hitSound.Play();
                }
                break;
            default:
                break;
        }

        ownHealthController.TakeDamage(damageTaken);
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
