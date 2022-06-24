using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;


public class AsteroidController : MyMonoBehaviour
{
    public Asteroid asteroid;

    public override void SafeOnDestroy()
    {
        if(GameManager.Instance.currentGameState == GameManager.GameState.INGAME)
            CreateAsteroids();
    }

    public void CreateAsteroids()
    {
        Debug.Log(asteroid.data.generateAsteroids);
        
        for (int i = 0; i < asteroid.data.generateAsteroids; i++)
        {
            var random = Random.insideUnitCircle.normalized*5;
            var a = AsteroidManager.Instance.CreateAsteroid((int)asteroid.data.asteroidType, transform.position + new Vector3(random.x,random.y));
            a.SetDirection(random.normalized*asteroid.data.initialForce);
        }
    }
}
