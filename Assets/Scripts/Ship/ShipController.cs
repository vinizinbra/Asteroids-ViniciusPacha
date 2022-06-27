using System;
using UnityEngine;

public class ShipController : Controller
{
    public Ship shipEntity;
    public MyPlayerInput input;

    private void Awake()
    {
        shipEntity.rbd.onCollision.AddListener( OnCollision );
    }

    private void OnDestroy()
    {
        shipEntity.rbd.onCollision.RemoveListener( OnCollision );
    }

    public override void MyFixedUpdate()
    {
        shipEntity.collisionDelay -= MyPhysics.FIXED_TIME_STEP;
        
        if (input.myInput.right)
            shipEntity.rbd.angle -= shipEntity.data.rotationSpeed*MyPhysics.FIXED_TIME_STEP;
        if (input.myInput.left)
            shipEntity.rbd.angle += shipEntity.data.rotationSpeed*MyPhysics.FIXED_TIME_STEP;
        
        if (shipEntity.isThrusting)
            shipEntity.rbd.AddForce(Vector2.up.Rotate(shipEntity.rbd.angle) ,shipEntity.data.propulsionSpeed);
    }

    private void Update()
    {
        shipEntity.isThrusting = input.myInput.up;
        
        if (input.myInput.fire)
            CreateProjectile();
    }

    void CreateProjectile()
    {
        var go = PoolManager.Instance.CreateObjectFromPool(shipEntity.data.projectilePrefab, shipEntity.rbd.Position,0);
        go.rbd.AddForce(transform.up,shipEntity.data.shootForce,true);
        go.rbd.angle = shipEntity.rbd.angle;
    }
    
    private void OnCollision(Entity other)
    {
        if (shipEntity.collisionDelay > 0) return;
        
        if (other is Asteroid)
        {
            GetHit();
            PoolManager.Instance.DisableObjectFromPool(other);
            
            OnAsteroidDestroyedEvent ev = new OnAsteroidDestroyedEvent();
            ev.asteroidObject = other as Asteroid;
            MyEventHandlerManager.MyEvents.Add(ev);
        }
    }

    public void GetHit()
    {
        shipEntity.currentLife -= 1;
        shipEntity.collisionDelay = shipEntity.data.collisionDelay;
        if (shipEntity.currentLife <= 0)
        {
            shipEntity.rbd.isEnabled = false;
            
            OnShipHitEvent ev = new OnShipHitEvent();
            ev.shipObject = shipEntity;
            MyEventHandlerManager.MyEvents.Add(ev);
        }
        
    }
}