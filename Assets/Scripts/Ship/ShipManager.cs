using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShipManager : MonoBehaviour
{
    public Ship[] ships;
    public static ShipManager Instance;
    public DebugPlayer debugPlayer;
    
    public UnityEvent onGetHit = new UnityEvent();
    void Awake()
    {
        if (PlayerManager.Instance != null)
        {
            for (int i = 0; i < PlayerManager.Instance.players.Count; i++)
            {
                ships[i].owner = PlayerManager.Instance.players[i];
            }
        }
        else
        {
            for (int i = 0; i < debugPlayer.players.Length; i++)
            {
                ships[i].owner = debugPlayer.players[i];
            }
        }
        Instance = this;
        
    }

}
