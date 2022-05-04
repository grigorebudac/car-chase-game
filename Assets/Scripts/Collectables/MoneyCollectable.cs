using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyCollectable : BaseCollectable
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
        // Debug.Log("Gaining Money");
    }
}
