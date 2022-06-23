using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/MyRigidbodyData", order = 1)]
public class MyRigidbodyData : ScriptableObject
{
    public float airdrag;
    public float mass = 1;

}
