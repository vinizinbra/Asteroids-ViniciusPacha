using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AsteroidView : MonoBehaviour
{
    public Asteroid asteroid;
    public SpriteRenderer image;
    public Sprite[] possibleSprites;
    public ParticleSystem explosionParticle;
    void Awake()
    {
        image.sprite = possibleSprites[Random.Range(0, possibleSprites.Length)];
        
    }

    private void Start()
    {
        MyEventHandler.Instance.onEvent.AddListener(OnAsteroidDestroyed);
    }

    void OnAsteroidDestroyed(MyEventBase arg0)
    {
        if (arg0 is OnAsteroidDestroyedEvent)
        {
            if((arg0 as OnAsteroidDestroyedEvent).asteroidObject == asteroid.rbd)
                CreateExplosionParticle();
        }
    }

    public void CreateExplosionParticle()
    {
        explosionParticle.UnparentAndPlay();
    }
}
