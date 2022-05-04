using UnityEngine;

public class HealthCollectable : BaseCollectable
{
    public override void OnTriggerEnter(Collider other)
    {
        if (other.GetComponentInParent<PlayerController>() != null)
        {
            PlayerController playerController = other.GetComponentInParent<PlayerController>();
            usePerk(playerController);
            Destroy(gameObject);
        }
    }

    public void usePerk(PlayerController playerController)
    {
        // Debug.Log("Healing Player");
        // playerController.Heal(10);
    }
}
