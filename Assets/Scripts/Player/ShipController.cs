using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MyMonoBehaviour
{
    public Ship shipEntity;
    public MyPlayerInput input;

  
    private void Awake()
    {
        shipEntity.rbd.onCollision.AddListener( OnCollision );
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
        var go = Instantiate(shipEntity.data.projectilePrefab, shipEntity.rbd.Position,Quaternion.identity);
        go.rbd.AddForce(transform.up,shipEntity.data.shootForce,true);
        go.rbd.angle = shipEntity.rbd.angle;
    }
    
    private void OnCollision(MyRigidbodyObject other)
    {
        if (shipEntity.collisionDelay > 0) return;
        
        if (other.collider.tag == MyCollider.Tag.ASTEROID)
        {
            GetHit();
            other.isDestroyed = true;
            MyPhysics.objectList.Remove(other);
            

        }
    }

    public void GetHit()
    {
        shipEntity.currentLife -= 1;
        shipEntity.collisionDelay = shipEntity.data.collisionDelay;
        if (shipEntity.currentLife <= 0)
        {
            shipEntity.rbd.MyDestroy();
        }

    }
}