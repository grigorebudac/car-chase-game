using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private HealthController healthController;

    private PlayerCollision()
    {
        this.healthController = new HealthController();
    }

    private void OnCollisionEnter(Collision collision)
    {
        PrometeoCarController car = gameObject.GetComponent<PrometeoCarController>();

        switch (collision.gameObject.tag)
        {
            case "Wall":
                this.HitWall(car.carSpeed);
                break;
            default:
                break;
        }

        Debug.Log("---> health: " + healthController.GetHealth());
    }

    private void HitWall(float carSpeed)
    {
        float damage = carSpeed / 10f;
        healthController.TakeDamage(damage);
    }
}
