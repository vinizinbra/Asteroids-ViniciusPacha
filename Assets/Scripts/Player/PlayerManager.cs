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
    public UnityEvent onChangePlayers = new UnityEvent();
    

}
