using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/GameConfigData", order = 1)]
public class GameConfigData : ScriptableObject
{
    public Vector2 gameArea;
    public float distanceFromPlayer;
}
