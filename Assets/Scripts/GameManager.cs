using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : Manager<GameManager>
{
    public UnityEvent onGameStarted = new UnityEvent();
    public UnityEvent onGameOver;
    public enum GameState
    {
        MENU,
        INGAME,
        GAMEOVER
    }

    public GameState currentGameState = GameState.MENU;

    public void StartGame()
    {
        currentGameState = GameState.INGAME;
        onGameStarted.Invoke();
        ShipManager.Instance.onGetHit.AddListener(CheckLoseCondition);
        AsteroidManager.Instance.onAsteroidDestroyed.AddListener(CheckWinCondition);
        
    } 
    public void GameOver()
    {
        currentGameState = GameState.GAMEOVER;
        onGameOver.Invoke();
    }
    public void Restart()
    {
        currentGameState = GameState.MENU;
        SceneManager.LoadScene("GameScene");
    }

    public void CheckLoseCondition()
    {
        int totalLives = 0;
        foreach (var ship in ShipManager.Instance.ships)
        {
            totalLives += ship.currentLife;
        }

        if (totalLives <= 0)
        {
            GameOver();
        }
    }
    public void CheckWinCondition(Asteroid asteroid)
    {
        if (asteroid.data.generateAsteroids > 0) return;
        
        if(AsteroidManager.Instance.instantiatedAsteroids.Count <= 0)
            GameOver();
    }

    private void Update()
    {
       
    }
}
