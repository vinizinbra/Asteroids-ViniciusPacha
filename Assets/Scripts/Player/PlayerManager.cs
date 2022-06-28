using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Player
{
    public class PlayerManager : Singleton<PlayerManager>
    {
        public List<Player> players;
        [HideInInspector]
        public static UnityEvent OnChangePlayers = new UnityEvent();

        private void Update()
        {
            

            HandlePlayerConnected();
            HandleInputs();
        }

        public void HandlePlayerConnected()
        {
            if (GameManager.Instance.CurrentGameState != GameManager.GameState.MENU) return;
            
            foreach (var player in players)
            {
                if (Input.GetKeyDown(player.inputData.thrust))
                {
                    player.isConnected = true;
                    OnChangePlayers.Invoke();
                }
                if (Input.GetKeyDown(player.inputData.down))
                {
                    player.isConnected = false;
                    OnChangePlayers.Invoke();
                }
            }
            
        }
        void HandleInputs(){
            foreach (var player in players)
            {
                if (player.isConnected)
                {
                    player.input.right = Input.GetKey(player.inputData.right);
                    player.input.left = Input.GetKey(player.inputData.left);
                    player.input.up = Input.GetKey(player.inputData.thrust);
                    player.input.down = Input.GetKey(player.inputData.down);
                    player.input.fire = Input.GetKeyDown(player.inputData.fire);
                }
            }

        }
    }
    
}
