using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class Asteroid : MonoBehaviour
{
    public int level = 1;
    private MyRigidbodyObject rbd;
    public float force;

    private bool alive = true;

    void Awake()
    {
        rbd = GetComponent<MyRigidbodyObject>();
    }
    public void OnDestroy()
    {
        Debug.Log("destroyAsteroid");
        level++;
        if (level < 3)
        {
            for (int i = 0; i <= level; i++)
            {
                var random = Random.insideUnitCircle.normalized*5;
                var a = AsteroidManager.instance.CreateAsteroid(level, transform.position + new Vector3(random.x,random.y));
                a.level = level;
                a.SetDirection(random.normalized*force);
            }
            
        }

        Destroy(this.gameObject);
    }

    public void SetDirection(Vector2 direction)
    {
        rbd.AddForce(direction.normalized,force,true);
        
    }

    private void Update()
    {
        if (!CustomPhysics.objectList.Contains(rbd))
        {
            Destroy(gameObject);
        }
    }
}
