using System;
using System.Collections;
using System.Collections.Generic;

public class InGameWindow : UiWindow
{
    public LifeWidget[] livesWidgets;
    private ShipManager _shipManager;
    public override void Show()
    {
	    base.Show();
	   
    }

    private void Start()
    {
	    _shipManager = ShipManager.Instance;
    }

    public void GameOver()
    {
		UiWindow.Show<GameOverWindow>();
		GameManager.Instance.GameOver();
    }

    private void Update()
    {
	    for (int i = 0; i < _shipManager.ships.Length; i++)
	    {
		    if (_shipManager.ships[i].owner.IsConnected)
		    {
			    livesWidgets[i].Setup(_shipManager.ships[i].currentLife);
		    }
		    else
		    {
			    livesWidgets[i].Setup(0);
		    }
		    
	    }
		    
    }
}
