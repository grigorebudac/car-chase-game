using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableSoundController : MonoBehaviour
{
    [SerializeField]
    private AudioSource perkSound; 
    [SerializeField]
    private AudioSource cashSound;
    
    public void OnTriggerEnter(Collider collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Collectable":
                if(perkSound != null)
                    perkSound.Play();
                break;
            case "Cash":
                if(cashSound != null)
                    cashSound.Play();
                break;
            default:
                break;
            
        }
    }
}
