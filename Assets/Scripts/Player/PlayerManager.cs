using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;
    public List<Ship> players = new List<Ship>();

    private void Awake()
    {
        instance = this;
    }
}
