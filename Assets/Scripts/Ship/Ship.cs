using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Ship : MonoBehaviour
{
    public Player owner;
    public float collisionDelay = 0;
    public MyRigidbodyObject rbd;
    public int currentLife;
    public ShipData data;
    public bool isThrusting;
    
    private Vector2 _startPosition;
    private float _startAngle;
    private void Start()
    {
        _startPosition = rbd.Position;
        _startAngle = rbd.angle;
        SetDefaultValues();
    }

    public void SetDefaultValues()
    {
        rbd.Position = _startPosition;
        rbd.angle = _startAngle;
        currentLife = data.maxLife;
    }
    
}
