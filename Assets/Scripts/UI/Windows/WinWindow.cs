using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinWindow : UiWindow
{
   
    public override void Show()
    {
	    base.Show();
	   
    }

    public void Update()
    {
    }
    
    public void Restart()
    {
	    GameManager.Instance.Restart();
    }
}
