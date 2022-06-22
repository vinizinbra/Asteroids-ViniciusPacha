using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/AsteroidGameConfigAsset", order = 1)]
public class AsteroidGameConfigAsset : ScriptableObject
{
    public Vector2 gameArea;
    public float distanceFromPlayer;
}
