using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/ShipData", order = 1)]
public class ShipData : ScriptableObject
{
    public int maxLife = 3;
    public float collisionDelay = 3;
    public float rotationSpeed = 4;
    public float propulsionSpeed = 14;
    public float shootForce = 50;
    public Projectile projectilePrefab;

}
