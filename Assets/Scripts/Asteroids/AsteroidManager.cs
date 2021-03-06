using Extensions;
using Global;
using Pool;
using Ship;
using UnityEngine;

namespace Asteroids
{
    public class AsteroidManager : Singleton<AsteroidManager>
    {
        public MapData mapData;
        public GameConfigData gameConfigData;
    
        void Start()
        {
            GameManager.OnGameStarted.AddListener(StartGame);
        }
    
        private void OnDestroy()
        {
            GameManager.OnGameStarted.RemoveListener(StartGame);
        }

        void StartGame()
        {
            for (int i = 0; i < gameConfigData.startAsteroids + GameManager.Instance.level; i++)
            {
                var randomPosition = GenerateRandomPosition();
                var a = CreateAsteroid(gameConfigData.asteroidPrefabs.Length-1,randomPosition);
                var dir = SetFirstDirection(randomPosition.ToVector3());
                a.SetDirection(dir);
            }
        }

        Vector3 SetFirstDirection(Vector3 from)
        {
            return Random.insideUnitCircle;
        }
    
        public Vector2 GenerateRandomPosition()
        {
            Vector2 randomPosition;
            do
            {
                float randomX = Random.Range(-mapData.gameArea.x, mapData.gameArea.x);
                float randomY = Random.Range(-mapData.gameArea.y, mapData.gameArea.y);
                randomPosition = new Vector2(randomX, randomY);

            } while (IsNearPlayer(randomPosition));

            return randomPosition;
        }
        public Asteroid CreateAsteroid(int index, Vector2 position)
        {
            var go = PoolManager.Instance.CreateObjectFromPool(gameConfigData.asteroidPrefabs[index],position,0);
            return go as Asteroid;
        }

        bool IsNearPlayer(Vector2 randomPosition)
        {
            
            return Vector2.Distance(ShipManager.Instance.ships[0].rbd.Position, randomPosition) < gameConfigData.distanceFromPlayer;
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawWireCube(transform.position,new Vector3(mapData.gameArea.x*2,mapData.gameArea.y*2,0.1f));
        }
    }
}
