using UI.Windows;
using UnityEngine.Serialization;

namespace Player
{
    [System.Serializable]
    public class Player
    {
        public string name;
        public bool IsConnected;
        public MyPlayerInput input = new MyPlayerInput();
        public PlayerInputMappingData inputData;
    
    }
}
