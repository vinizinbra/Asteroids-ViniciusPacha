using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;


public class Asteroid : MyMonoBehaviour
{
    [HideInInspector]
    public MyRigidbodyObject rbd;
    
    public AsteroidData data;

    void Awake()
    {
        rbd = GetComponent<MyRigidbodyObject>();
    }

    public override void SafeOnDestroy()
    {
        CreateAsteroids();
    }

    public void SetDirection(Vector2 direction)
    {
        rbd.AddForce(direction.normalized,data.initialForce,true);
    }

    public void CreateAsteroids()
    {
        for (int i = 0; i < data.generateAsteroids; i++)
        {
            var random = Random.insideUnitCircle.normalized*5;
            var a = AsteroidManager.instance.CreateAsteroid((int)data.asteroidType, transform.position + new Vector3(random.x,random.y));
            a.SetDirection(random.normalized*data.initialForce);
        }
    }
}
