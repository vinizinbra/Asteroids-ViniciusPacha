using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MenuWindow : UiWindow
{
	private PlayerManager _playerManager;
	
	void Start()
    {
	    _playerManager = PlayerManager.Instance;
    }
   
    public override void Show()
    {
	    base.Show();
    }

    public void StartGame()
    {
	    GameManager.Instance.StartGame();
	    UiWindow.Show<InGameWindow>();
    }

    private void Update()
    {
	    foreach (var player in _playerManager.players)
	    {
		    if (Input.GetKeyDown(player.input.thrust))
		    {
			    player.IsConnected = true;
			    _playerManager.onChangePlayers.Invoke();
		    }
		    if (Input.GetKeyDown(player.input.down))
		    {
			    player.IsConnected = false;
			    _playerManager.onChangePlayers.Invoke();
		    }
	    }
    }
}
