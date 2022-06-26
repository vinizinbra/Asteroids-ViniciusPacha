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
            ev.asteroidObject = other.rbd;
            MyEventHandler.Instance.myEvents.Add(ev);
        }
    }

    public void GetHit()
    {
        shipEntity.currentLife -= 1;
        ShipManager.Instance.onGetHit.Invoke();
        shipEntity.collisionDelay = shipEntity.data.collisionDelay;
        if (shipEntity.currentLife <= 0)
        {
            shipEntity.rbd.isEnabled = false;
            
            OnShipDestroyedEvent ev = new OnShipDestroyedEvent();
            ev.shipObject = shipEntity.rbd;
            MyEventHandler.Instance.myEvents.Add(ev);
        }
        
    }
}