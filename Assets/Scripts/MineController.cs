using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MineController : MonoBehaviour
{
    
    [SerializeField] private GameObject _particles;
    
    private float _explosionRadius = 5;
    private float _explosionForce = 500000;

    private void OnTriggerEnter(Collider other)
    {
        var surroundingObjects = Physics.OverlapSphere(transform.position, _explosionRadius);
 
        foreach (var obj in surroundingObjects) {
            var rb = obj.GetComponent<Rigidbody>();
            if (obj.gameObject.name == "CarCollider")
            {
                rb = obj.gameObject.GetComponentInParent<Rigidbody>();
            }
            if (rb == null) continue;

            rb.AddExplosionForce(_explosionForce, transform.position, _explosionRadius,1);
        }
 
        Instantiate(_particles, transform.position, Quaternion.identity);
 
        Destroy(gameObject);
    }
}
