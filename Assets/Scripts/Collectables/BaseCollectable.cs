
using System;
using UnityEngine;
public abstract class BaseCollectable : MonoBehaviour
{
    public virtual void OnTriggerEnter(Collider other)
    {
        if (other.GetComponentInParent<PlayerController>() != null)
        {
            PlayerController playerController = other.GetComponentInParent<PlayerController>();
            GameObject perk = PerkMapping.PerkMapToGameObject.TryGetValue(this.GetType(), out perk) ? perk : null;
            if (perk != null)
            {
                playerController.setPerk(perk);
            }

            Destroy(gameObject);
        }
    }
}