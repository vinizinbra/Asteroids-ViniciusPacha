using System;
using Unity.VisualScripting;
using UnityEditor.Analytics;
using UnityEngine;

public class ProjectileController : MyMonoBehaviour
{
    public Projectile projectile;
    
    private void Awake()
    {
        projectile.rbd.onCollision.AddListener( OnCollision );
    }

    public override void MyFixedUpdate()
    {
        base.MyFixedUpdate();
        projectile.currentDistance += (projectile.rbd.Velocity * MyPhysics.FIXED_TIME_STEP).magnitude;
        if (projectile.currentDistance >= projectile.data.maxDistance)
        {
            MyPhysics.RemoveBody(projectile.rbd);
            projectile.rbd.isDestroyed = true;
        }
    }

    private void OnDestroy()
    {
        projectile.rbd.onCollision.RemoveListener(OnCollision);
    }

    private void OnCollision(MyRigidbodyObject other)
    {
        if (other.collider.tag == MyCollider.Tag.ASTEROID)
        {
            projectile.rbd.MyDestroy();
            other.MyDestroy();
            
            OnAsteroidDestroyedEvent e = new OnAsteroidDestroyedEvent();
            e.asteroidObject = other;
            MyEventHandler.Instance.myEvents.Add(e);
        }
    }

}