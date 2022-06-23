using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

public class AsteroidManager : MonoBehaviour
{
    public GameConfigData config;
    public int asteroidIdCounter = 0;
    public Asteroid[] asteroidPrefabs;
    public int asteroidCount = 1;
    public static AsteroidManager instance;
    
    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        StartGame();
    }
    void StartGame()
    {
        for (int i = 0; i < asteroidCount; i++)
        {
            var randomPosition = GenerateRandomPosition();
            var a = CreateAsteroid(asteroidPrefabs.Length-1,randomPosition);
            var dir = SetFirstDirection(randomPosition.ToVector3());
            a.SetDirection(dir);
        }
    }

    Vector3 SetFirstDirection(Vector3 from)
    {
        return PlayerManager.instance.players[0].transform.position - from;
    }
    public Vector2 GenerateRandomPosition()
    {
        Vector2 randomPosition;
        do
        {
            float randomX = Random.Range(-config.gameArea.x, config.gameArea.x);
            float randomY = Random.Range(-config.gameArea.y, config.gameArea.y);
            randomPosition = new Vector2(randomX, randomY);

        } while (IsNearPlayer(randomPosition));

        return randomPosition;
    }
    public Asteroid CreateAsteroid(int index, Vector2 position)
    {
        asteroidIdCounter++;
        var go = Instantiate(asteroidPrefabs[index],position,Quaternion.identity);
        go.name += string.Format("ID {0}", asteroidIdCounter);
        return go;
    }

    bool IsNearPlayer(Vector2 randomPosition)
    {
        return Vector2.Distance(PlayerManager.instance.players[0].rbd.Position, randomPosition) < config.distanceFromPlayer;
    }
    
    
}
