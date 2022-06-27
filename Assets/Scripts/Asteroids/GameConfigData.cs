using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameConfigData : ScriptableObject
{
    [Header("Asteroid Global Config")]
    public float distanceFromPlayer;
    public float asteroidForce;
    public int startAsteroids;
    public Asteroid[] asteroidPrefabs;
}