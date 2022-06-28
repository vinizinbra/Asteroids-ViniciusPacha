using UI.Windows;
using UnityEngine.Serialization;

namespace Player
{
    [System.Serializable]
    public class Player
    {
        public string name;
        public bool isConnected;
        public MyPlayerInput input = new MyPlayerInput();
        public PlayerInputMappingData inputData;
    
    }
}
