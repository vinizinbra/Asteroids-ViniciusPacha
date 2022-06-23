using System;
using UnityEngine;

public class MyCollider : MonoBehaviour
{
    public enum Tag
    {
        PLAYER,
        ASTEROID,
        BULLET
    }
    
    public Tag tag;
    public float radius;

    public bool CheckCollision(MyRigidbodyObject objA,MyRigidbodyObject objB)
    {
        float maxDistance = objA.collider.radius + objB.collider.radius;
        float totalDistance = Vector2.Distance(objA.Position, objB.Position);
        return totalDistance < (maxDistance-1);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        
        Gizmos.DrawWireSphere(transform.position,radius);
    }
}