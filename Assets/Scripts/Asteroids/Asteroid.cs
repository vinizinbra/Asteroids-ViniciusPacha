using CustomPhysics;
using UnityEngine;


namespace Asteroids
{
    public class Asteroid : Entity
    {
        public AsteroidData data;

        void Awake()
        {
            rbd = GetComponent<MyRigidbodyObject>();
        }

        public void SetDirection(Vector2 direction)
        {
            rbd.AddForce(direction.normalized,data.initialForce,true);
        }

    }
}
