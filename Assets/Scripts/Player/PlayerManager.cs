using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class PlayerManager : Singleton<PlayerManager>
{
    public List<Player> players;
    [HideInInspector]
    public static UnityEvent OnChangePlayers = new UnityEvent();

    private void Update()
    {
        if (GameManager.Instance.CurrentGameState == GameManager.GameState.MENU)
        {
            foreach (var player in players)
            {
                if (Input.GetKeyDown(player.input.thrust))
                {
                    player.IsConnected = true;
                    OnChangePlayers.Invoke();
                }
                if (Input.GetKeyDown(player.input.down))
                {
                    player.IsConnected = false;
                    OnChangePlayers.Invoke();
                }
            }
        }
    }
    
}
