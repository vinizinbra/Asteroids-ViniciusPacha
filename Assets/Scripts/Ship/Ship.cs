using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public float collisionDelay = 0;
    public MyRigidbodyObject rbd;
    public int currentLife;
    public ShipData data;
    public bool accelerate;

    void Start()
    {
        currentLife = data.maxLife;
    }
}
