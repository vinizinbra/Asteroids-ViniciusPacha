using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
