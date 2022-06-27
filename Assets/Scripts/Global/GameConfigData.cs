using Asteroids;
using UnityEngine;

namespace Global
{
    public class GameConfigData : ScriptableObject
    {
        [Header("Asteroid Global Config")]
        public float distanceFromPlayer;
        public float asteroidForce;
        public int startAsteroids;
        public Asteroid[] asteroidPrefabs;
    }
}