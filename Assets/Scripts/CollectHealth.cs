using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectHealth : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        other.GetComponentInParent<PlayerController>().Heal(10);
        Destroy(gameObject);
    }
}
