using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerCollision
{
    void OnCollisionEnter(Collision collision);
    void OnTriggerEnter(Collider other);
}
