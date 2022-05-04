using UnityEngine;

public class HealthCollectable : BaseCollectable
{
    public override void OnTriggerEnter(Collider other)
    {
        if (other.GetComponentInParent<PlayerController>() != null)
        {
            HealthController healthController = other.GetComponentInParent<PlayerController>().carHealth;
            usePerk(healthController);
            Destroy(gameObject);
        }
    }

    public void usePerk(HealthController healthController)
    {
        healthController.Heal(10);
    }
}
