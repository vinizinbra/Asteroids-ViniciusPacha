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
        private void Awake()
        {
            _startPosition = transform.position;
            _startAngle = 0;
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
