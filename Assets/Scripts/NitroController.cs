using System;
using System.Collections;
using UnityEngine;

public class NitroController : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem LeftNitroParticle;
    [SerializeField]
    private ParticleSystem RightNitroParticle;
    [SerializeField]
    private AudioSource NitroSound;
    
    [SerializeField]
    private int inpulse = 10000;

    private static float TIME = 2f;
    
    private void Start()
    {
        if (LeftNitroParticle != null)
        {
            LeftNitroParticle.Stop();
        }

        if (RightNitroParticle != null)
        {
            RightNitroParticle.Stop();
        }
    }

    public void UseNitro(Rigidbody rigidbody)
    {
        StartCoroutine(ApplyNitro(rigidbody));
    }
    
    public IEnumerator ApplyNitro(Rigidbody rigidbody)
    {
        rigidbody.AddForce(transform.forward * inpulse , ForceMode.Impulse);

        LeftNitroParticle.Play();
        RightNitroParticle.Play();
        NitroSound.Play();
        
        yield return new WaitForSeconds(TIME);

        ResetNitro();
    }

    public void ResetNitro()
    {
        LeftNitroParticle.Stop();
        RightNitroParticle.Stop();
        NitroSound.Stop();
    }
}
