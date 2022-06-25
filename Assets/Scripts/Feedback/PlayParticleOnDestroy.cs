using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayParticleOnDestroy : MonoBehaviour
{
    public bool isQuitting;
    public ParticleSystem particle;

    public void OnApplicationQuit()
    {
        isQuitting = true;
    }

    private void Reset()
    {
        particle = GetComponent<ParticleSystem>();
    }

    private void OnDestroy()
    {
        if(isQuitting)
            return;
        
    }
}
