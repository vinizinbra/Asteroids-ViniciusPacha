using CustomPhysics;

namespace Projectile
{
    public class Projectile : Entity
    {
        public float currentDistance;
    
    
        public ProjectileData data;

        public override void Reset()
        {
            base.Reset();
            currentDistance = 0;
        
        }
    }
}
