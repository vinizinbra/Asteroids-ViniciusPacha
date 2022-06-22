using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

public class AsteroidManager : MonoBehaviour
{
    public AsteroidGameConfigAsset config;

    public Asteroid[] asteroidPrefabs;

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
        for (int i = 0; i < 6; i++)
        {
            var randomPosition = GenerateRandomPosition();
            CreateAsteroid(0,randomPosition);
        }
    }

    public Vector2 GenerateRandomPosition()
    {
        Vector2 randomPosition;
        do
        {
            float randomX = Random.Range(-config.gameArea.x / 2.0f, config.gameArea.x / 2.0f);
            float randomY = Random.Range(-config.gameArea.y / 2.0f, config.gameArea.y / 2.0f);
            randomPosition = new Vector2(randomX, randomY);

        } while (IsNearPlayer(randomPosition));

        return randomPosition;
    }
    public Asteroid CreateAsteroid(int index, Vector2 position)
    {
        var go = Instantiate(asteroidPrefabs[index],position,Quaternion.identity);
        return go;
    }

    bool IsNearPlayer(Vector2 randomPosition)
    {
        return Vector2.Distance(PlayerManager.instance.player.rbd.Position, randomPosition) < config.distanceFromPlayer;
    }
    
    
}
