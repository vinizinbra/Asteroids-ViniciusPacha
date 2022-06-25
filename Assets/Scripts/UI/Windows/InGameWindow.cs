using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class InGameWindow : UiWindow
{
	public TMP_Text level;
    public LifeWidget[] livesWidgets;
    
    private ShipManager _shipManager;
    public override void Show()
    {
	    base.Show();
	    level.text = string.Format("Level {0}",GameManager.Instance.level);
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
		    livesWidgets[i].gameObject.SetActive(_shipManager.ships[i].owner.IsConnected);

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
