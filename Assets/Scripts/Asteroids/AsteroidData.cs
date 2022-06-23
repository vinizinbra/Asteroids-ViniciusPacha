using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/AsteroidData", order = 1)]

public class AsteroidData : ScriptableObject
{
    public float initialForce = 10;
    public int generateAsteroids = 1;
    public AsteroidType asteroidType;
    
    public enum AsteroidType
    {
        SMALL,
        MEDIUM,
        BIG
    }
}
