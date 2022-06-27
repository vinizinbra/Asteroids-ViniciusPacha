using System;
using UI.Base;
using UI.Windows;

namespace UI
{
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
            GameManager.OnGameStateChanged.AddListener(GameStateChanged);
        }

        private void OnDestroy()
        {
            GameManager.OnGameStateChanged.RemoveListener(GameStateChanged);
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
}
