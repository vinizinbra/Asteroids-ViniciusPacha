using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;


public class Asteroid : Entity
{
    public AsteroidData data;

    void Awake()
    {
        rbd = GetComponent<MyRigidbodyObject>();
        AsteroidManager.Instance.instantiatedAsteroids.Add(this);
    }

    private void OnDestroy()
    {
        AsteroidManager.Instance.instantiatedAsteroids.Remove(this);
    }

    public void SetDirection(Vector2 direction)
    {
        rbd.AddForce(direction.normalized,data.initialForce,true);
    }

}
