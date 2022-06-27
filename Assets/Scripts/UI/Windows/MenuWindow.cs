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
    }

}
