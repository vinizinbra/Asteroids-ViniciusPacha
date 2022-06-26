using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : Manager<GameManager>
{
    public UnityEvent onGameStarted = new UnityEvent();
    public UnityEvent onGameOver = new UnityEvent();

    public int level = 0;
    public enum GameState
    {
        MENU,
        INGAME,
        GAMEOVER,
        WIN
        
    }

    public GameState currentGameState = GameState.MENU;

    public void StartGame()
    {
        currentGameState = GameState.INGAME;
        onGameStarted.Invoke();
        ShipManager.Instance.onGetHit.AddListener(CheckLoseCondition);
        MyEventHandlerManager.Instance.onEvent.AddListener(OnAsteroidDestroyedEvent);
        MyEventHandlerManager.Instance.onEvent.AddListener(OnShipDestroyedEvent);
    }

    private void OnShipDestroyedEvent(MyEventBase arg0)
    {
        if (arg0 is OnShipDestroyedEvent)
        {
            Debug.Log("OnShipDestroyedEvent");
            CheckLoseCondition();
        }    
    }

    private void OnAsteroidDestroyedEvent(MyEventBase arg0)
    {
        if (arg0 is OnAsteroidDestroyedEvent)
        {
            var asteroid = (arg0 as OnAsteroidDestroyedEvent).asteroidObject;
            CheckWinCondition(asteroid);
        }
    }

    public void GameOver()
    {
        level = 0;
        currentGameState = GameState.GAMEOVER;
        onGameOver.Invoke();
    }
    public void Win()
    {
        if (currentGameState == GameState.WIN) return;
        
        level++;
        currentGameState = GameState.WIN;
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
            if(ship.owner.IsConnected)
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
        
        Debug.Log("OBJ IN LIST => "+MyPhysics.objectList.Count);
        if(!MyPhysics.objectList.Any(x=> x is Asteroid && x.rbd.isEnabled))
            Win();
    }

}
