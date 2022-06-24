using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public UnityEvent onGameStarted;
    public UnityEvent onGameOver;
    public UnityEvent onGameReset;
    public enum GameState
    {
        MENU,
        INGAME,
        GAMEOVER
    }

    public GameState currentGameState = GameState.MENU;
    private void Awake()
    {
        DontDestroyOnLoad(this);
        Instance = this;
    }

    public void StartGame()
    {
        currentGameState = GameState.INGAME;
        onGameStarted.Invoke();
        
    } 
    public void GameOver()
    {
        currentGameState = GameState.GAMEOVER;
        onGameOver.Invoke();
    }
    public void Restart()
    {
        currentGameState = GameState.MENU;
        onGameReset.Invoke();
        SceneManager.LoadScene("GameScene");
    }
}
