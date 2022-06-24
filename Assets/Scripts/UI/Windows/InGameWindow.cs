using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameWindow : UiWindow
{
    public static InGameWindow instance;
	void Awake()
    {
	    instance = this;
    }
   
    public override void Show()
    {
	    base.Show();
	   
    }

    public void GameOver()
    {
		UiWindow.Show<GameOverWindow>();
		GameManager.Instance.GameOver();
    }
}
