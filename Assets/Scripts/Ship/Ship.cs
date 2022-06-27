using CustomPhysics;
using UnityEngine;

namespace Ship
{
    public class Ship : Entity
    {
        public Player.Player owner;
        public float collisionDelay = 0;
        public int currentLife;
        public bool isThrusting;
    
        private Vector2 _startPosition;
        private float _startAngle;
    
        public ShipData data;

        public ShipView view;
        private void Start()
        {
            _startPosition = rbd.Position;
            _startAngle = rbd.angle;
            SetDefaultValues();
        }

        public void SetDefaultValues()
        {
            rbd.Position = _startPosition;
            rbd.angle = _startAngle;
            currentLife = data.maxLife;
            collisionDelay = 0;
        }
    
    }
}
