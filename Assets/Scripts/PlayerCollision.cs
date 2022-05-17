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
        if (collision.gameObject.tag == "Props") return;
        PlayerController playerController = gameObject.GetComponent<PlayerController>();
        PrometeoCarController car = gameObject.GetComponent<PrometeoCarController>();
        HealthController ownHealthController = playerController.carHealth;

        if (playerController.isUsingShield)
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
            case "PolicePlayer":
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

    public void OnTriggerEnter(Collider other)
    {
        PlayerController playerController = gameObject.GetComponent<PlayerController>();
        if (playerController && playerController.isUsingShield)
        {
            return;
        }

        if (other.gameObject.tag == "Props") return;
        if (other.gameObject.tag == "Building")
        {
            HealthController healthController = gameObject.GetComponent<HealthController>();
            healthController.TakeDamage(100f);
        }

        if (other.gameObject.GetComponentInParent<ECCar>())
        {
            HealthController healthController = gameObject.GetComponent<HealthController>();
            healthController.TakeDamage(25f);

        }
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
