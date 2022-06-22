using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MyPlayerInput : MonoBehaviour
{
    [System.Serializable]
    public struct PlayerInput
    {
        public bool right;
        public bool left;
        public bool down;
        public bool up;
        public bool space;
    }

    public PlayerInput input = new PlayerInput();
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        input.right = Input.GetKey(KeyCode.RightArrow);
        input.left = Input.GetKey(KeyCode.LeftArrow);
        input.up = Input.GetKey(KeyCode.UpArrow);
        input.down = Input.GetKey(KeyCode.DownArrow);
        input.space = Input.GetKeyDown(KeyCode.Space);
    }
}
