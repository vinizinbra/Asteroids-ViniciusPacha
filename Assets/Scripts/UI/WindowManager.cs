using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowManager : Singleton<WindowManager>
{
    public UiWindow[] uiWindows;

    protected override void Awake()
    {
        base.Awake();
        
        uiWindows = GetComponentsInChildren<UiWindow>(true);
        UiWindow.Show<MenuWindow>();
    }

    private void Start()
    {
        GameManager.Instance.onGameStateChanged.AddListener(GameStateChanged);
    }

    public void GameStateChanged(GameManager.GameState currentGameState)
    {
        switch(currentGameState)
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
            case GameManager.GameState.WIN:
                UiWindow.Show<WinWindow>();
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}
