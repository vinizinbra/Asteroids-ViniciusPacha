using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public int level = 1;
    private MyRigidbodyObject rbd;
    public float force;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DestroyAsteroid()
    {
        level++;
        for (int i = 0; i < level; i++)
        {
            var random = Random.insideUnitCircle;
            var a = AsteroidManager.instance.CreateAsteroid(level, transform.position + new Vector3(random.x,random.y));
            a.level = level;
            a.SetDirection(Random.insideUnitCircle.normalized*force);
        }

        Destroy(this.gameObject);
    }

    void SetDirection(Vector2 direction)
    {
        rbd.AddForce(direction,force,true);
        
    }
}
