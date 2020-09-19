using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particleTrigger : MonoBehaviour
{
    public void TriggerParticles()
    {
        ParticleSystem myParticle = GetComponent<ParticleSystem>();
        if(myParticle != null)
        {
            GetComponent<ParticleSystem>().Play();
        }
    }
}
