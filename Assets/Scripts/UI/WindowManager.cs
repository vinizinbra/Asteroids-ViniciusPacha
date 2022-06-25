using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowManager : MonoBehaviour
{
    public static WindowManager instance; 
    public UiWindow[] uiWindows; 
    void Awake()
    {
        instance = this;
        uiWindows = GetComponentsInChildren<UiWindow>(true);
        UiWindow.Show<MenuWindow>();
    }

    private void Update()
    {
        switch(GameManager.Instance.currentGameState)
        {
            case GameManager.GameState.MENU:
                UiWindow.Show<MenuWindow>();
                break;
            case GameManager.GameState.INGAME:
                UiWindow.Show<InGameWindow>();
                break;
            case GameManager.GameState.GAMEOVER:
                UiWindow.Show<GameOverWindow>();
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}
