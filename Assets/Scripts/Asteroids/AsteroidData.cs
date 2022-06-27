using UnityEngine;

namespace Asteroids
{
    public class AsteroidData : ScriptableObject
    {
        public float initialForce = 10;
        public int generateAsteroids = 1;
        public AsteroidType asteroidType;
    
        public enum AsteroidType
        {
            SMALL,
            MEDIUM,
            BIG
        }
    }
}
