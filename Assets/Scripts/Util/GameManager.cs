using System.Linq;
using UnityEngine.Events;

public class GameManager : Singleton<GameManager>
{
    public UnityEvent onGameStarted = new UnityEvent();
    public UnityEvent onGameRestart = new UnityEvent();
    public UnityEvent<GameState> onGameStateChanged = new UnityEvent<GameState>();

    public int level = 0;
    public enum GameState
    {
        MENU,
        INGAME,
        GAMEOVER,
        WIN
        
    }

    private GameState _currentGameState = GameState.MENU;

    private GameState CurrentGameState
    {
        get => _currentGameState;
        set
        {
            if(_currentGameState != value)
                onGameStateChanged.Invoke(value);
            _currentGameState = value;
        }
    }

    public void StartGame()
    {
        CurrentGameState = GameState.INGAME;
        onGameStarted.Invoke();
        MyEventHandlerManager.Instance.onEvent.AddListener(OnAsteroidDestroyedEvent);
        MyEventHandlerManager.Instance.onEvent.AddListener(OnShipHitEvent);
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
        onGameRestart.Invoke();
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
        
        if(!MyPhysics.objectList.Any(x=> x is Asteroid && x.rbd.isEnabled))
            Win();
    }

}
