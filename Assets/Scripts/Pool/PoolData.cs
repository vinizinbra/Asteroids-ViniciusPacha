using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PoolData : ScriptableObject
{
    public int initValue;
    public Entity[] prefabs;
}
