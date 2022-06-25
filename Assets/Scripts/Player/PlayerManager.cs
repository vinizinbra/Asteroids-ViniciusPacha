using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance;
    public List<Player> players;
    [HideInInspector]
    public UnityEvent onChangePlayers = new UnityEvent();
    private void Awake()
    {
        Instance = this;
        
        DontDestroyOnLoad(this);
    }

}
