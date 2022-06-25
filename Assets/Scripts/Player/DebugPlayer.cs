using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DebugPlayer : MonoBehaviour
{
    public Player[] players;

    private void Awake()
    {
        if (PlayerManager.Instance != null) return;
        var p = gameObject.AddComponent<PlayerManager>();
        p.players = players.ToList();
        
    }
}
