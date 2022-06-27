using System;
using System.Linq;
using Asteroids;
using CustomPhysics;
using MyEvents;
using Ship;
using UnityEngine.Events;

public class GameManager : Singleton<GameManager>
{
    public static UnityEvent OnGameStarted = new UnityEvent();
    public static UnityEvent OnGameRestarted = new UnityEvent();
    public static UnityEvent<GameState> OnGameStateChanged = new UnityEvent<GameState>();

    public int level = 0;
    public enum GameState
    {
        MENU,
        INGAME,
        GAMEOVER,
        WIN
        
    }

    private GameState _currentGameState = GameState.MENU;
    public GameState CurrentGameState
    {
        get => _currentGameState;
        set
        {
            if(_currentGameState != value)
                OnGameStateChanged.Invoke(value);
            _currentGameState = value;
        }
    }

    public void StartGame()
    {
        CurrentGameState = GameState.INGAME;
        OnGameStarted.Invoke();
        MyEventHandlerManager.OnEvent.AddListener(OnAsteroidDestroyedEvent);
        MyEventHandlerManager.OnEvent.AddListener(OnShipHitEvent);
    }

    private void OnDestroy()
    {
        MyEventHandlerManager.OnEvent.RemoveListener(OnAsteroidDestroyedEvent);
        MyEventHandlerManager.OnEvent.RemoveListener(OnShipHitEvent);
    }

    private void OnShipHitEvent(MyEventBase arg0)
    {
        if (arg0 is OnShipHitEvent)
        {
            CheckLoseCondition();
        }
    }

    private void OnAsteroidDestroyedEvent(MyEventBase arg0)
    {
        if (arg0 is OnAsteroidDestroyedEvent)
        {
            var asteroid = (arg0 as OnAsteroidDestroyedEvent).asteroidObject;
            
            if(asteroid.data.generateAsteroids <= 0)
                CheckWinCondition(asteroid);
        }
    }

    public void GameOver()
    {
        level = 0;
        CurrentGameState = GameState.GAMEOVER;
    }
    public void Win()
    {
        if (_currentGameState == GameState.WIN) return;
        
        level++;
        CurrentGameState = GameState.WIN;
    }
    public void Restart()
    {
        CurrentGameState = GameState.MENU;
        OnGameRestarted.Invoke();
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
        if(!MyPhysics.objectList.Any(x=> x is Asteroid && x.rbd.isEnabled))
            Win();
    }

}
