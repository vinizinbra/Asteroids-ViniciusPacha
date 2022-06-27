using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;


public class AsteroidController : Controller
{
    public Asteroid asteroid;

    private void Start()
    {
        MyEventHandlerManager.Instance.onEvent.AddListener(OnAsteroidDestroyed);
    }

    void OnAsteroidDestroyed(MyEventBase arg0)
    {
        if (arg0 is OnAsteroidDestroyedEvent)
        {
            Debug.Log("on asteroid destroyed");

            if ((arg0 as OnAsteroidDestroyedEvent).asteroidObject == asteroid)
            {
                Debug.Log("try create asteroids");
                TryToCreateAsteroids();
            }
        }
    }
    
    public void TryToCreateAsteroids()
    {
        for (int i = 0; i < asteroid.data.generateAsteroids; i++)
        {
            var random = Random.insideUnitCircle.normalized*5;
            var a = AsteroidManager.Instance.CreateAsteroid((int)asteroid.data.asteroidType, transform.position + new Vector3(random.x,random.y));
            a.SetDirection(random.normalized*asteroid.data.initialForce);
        }
    }
}
