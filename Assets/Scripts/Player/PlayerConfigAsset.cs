using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/PlayerConfigAsset", order = 1)]
public class PlayerConfigAsset : ScriptableObject
{
    public float rotationSpeed = 1;
    public float propulsionSpeed = 1;
    public float shootForce = 2;
}
