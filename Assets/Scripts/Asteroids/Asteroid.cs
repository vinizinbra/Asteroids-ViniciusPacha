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
    }

    public void SetDirection(Vector2 direction)
    {
        rbd.AddForce(direction.normalized,data.initialForce,true);
    }

}
