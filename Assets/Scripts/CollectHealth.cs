using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectHealth : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        other.GetComponentInParent<PrometeoCarController>().carHealth.Heal(10);
        Destroy(gameObject);
    }
}
