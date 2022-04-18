using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        PrometeoCarController car = gameObject.GetComponent<PrometeoCarController>();
        float damageTaken = 0;

        switch (collision.gameObject.tag)
        {
            case "Wall":
                damageTaken = this.GetHitByWallDamage(car.carSpeed);
                break;
            case "PoliceNPC":
            case "PolicePlayer":
                PrometeoCarController policeCar = collision.gameObject.GetComponent<PrometeoCarController>();
                damageTaken = this.GetHitByPoliceCarDamage(policeCar.carSpeed);
                break;
            default:
                break;
        }

        car.carHealth.TakeDamage(damageTaken);
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
