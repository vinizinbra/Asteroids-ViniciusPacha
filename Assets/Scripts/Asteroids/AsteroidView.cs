using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidView : MonoBehaviour
{
    public SpriteRenderer image;
    public Sprite[] possibleSprites;
    void Awake()
    {
        image.sprite = possibleSprites[Random.Range(0, possibleSprites.Length)];
    }
}
