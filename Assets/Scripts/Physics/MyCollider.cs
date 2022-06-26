using System;
using UnityEngine;

public class MyCollider : MonoBehaviour
{
    public float radius;

    public bool CheckCollision(Entity objA,Entity objB)
    {
        float maxDistance = objA.rbd.collider.radius + objB.rbd.collider.radius;
        float totalDistance = Vector2.Distance(objA.rbd.Position, objB.rbd.Position);
        return totalDistance < (maxDistance-1);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        
        Gizmos.DrawWireSphere(transform.position,radius);
    }
}