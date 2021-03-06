using Asteroids;
using CustomPhysics;
using MyEvents;
using Pool;

namespace Projectile
{
    public class ProjectileController : Controller
    {
        public Projectile projectile;
    
        private void Awake()
        {
            projectile.rbd.onCollision.AddListener( OnCollision );
        }
        private void OnDestroy()
        {
            projectile.rbd.onCollision.RemoveListener(OnCollision);
        }
    
        public override void MyFixedUpdate()
        {
            base.MyFixedUpdate();
            projectile.currentDistance += (projectile.rbd.Velocity * MyPhysics.FIXED_TIME_STEP).magnitude;
            if (projectile.currentDistance >= projectile.data.maxDistance)
            {
                PoolManager.Instance.DisableObjectFromPool(projectile);
            }
        }

   

        private void OnCollision(Entity other)
        {
            if (other is Asteroid)
            {
                PoolManager.Instance.DisableObjectFromPool(projectile);
                var asteroid = other as Asteroid;
                PoolManager.Instance.DisableObjectFromPool(asteroid);

                OnAsteroidDestroyedEvent e = new OnAsteroidDestroyedEvent();
                e.asteroidObject = other as Asteroid;
                MyEventHandlerManager.MyEvents.Add(e);
            }
        }

    }
}