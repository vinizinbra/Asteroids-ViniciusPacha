using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShipManager : Singleton<ShipManager>
{
    public Ship[] ships;
    private void Start()
    {
        if (PlayerManager.Instance != null)
        {
            for (int i = 0; i < PlayerManager.Instance.players.Count; i++)
            {
                ships[i].owner = PlayerManager.Instance.players[i];
            }
        }
        
        GameManager.OnGameRestarted.AddListener(ResetShips);
        PlayerManager.OnChangePlayers.AddListener(ResetShips);
        ResetShips();
    }

    private void OnDestroy()
    {
        GameManager.OnGameRestarted.RemoveListener(ResetShips);
        PlayerManager.OnChangePlayers.RemoveListener(ResetShips);

    }

    void ResetShips()
    {
        foreach (var s in ships)
        {
            s.Reset();
            s.SetDefaultValues();
        }
        UpdateShips();
    }

    void UpdateShips()
    {
        foreach (var ship in ships)
        {
            ship.rbd.isEnabled = ship.owner.IsConnected;
            ship.view.UpdateShipView();
        }
    }
}
