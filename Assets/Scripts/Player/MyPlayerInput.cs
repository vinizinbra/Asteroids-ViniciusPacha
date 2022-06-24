using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class MyPlayerInput : MonoBehaviour
{
    private Ship ship;
    
    [System.Serializable]
    public struct PlayerInput
    {
        public bool right;
        public bool left;
        public bool down;
        public bool up;
        public bool fire;
    }

    public PlayerInput myInput = new PlayerInput();

    void Awake()
    {
        ship = GetComponent<Ship>();
    }
    // Update is called once per frame
    void Update()
    {
        if (ship.owner == null) return;
        
        myInput.right = Input.GetKey(ship.owner.input.right);
        myInput.left = Input.GetKey(ship.owner.input.left);
        myInput.up = Input.GetKey(ship.owner.input.thrust);
        myInput.down = Input.GetKey(ship.owner.input.down);
        myInput.fire = Input.GetKeyDown(ship.owner.input.fire);
    }
}
