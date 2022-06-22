using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class MyRigidbodyObject : MonoBehaviour
{
    public Vector2 Position; // struct with 3 floats for x, y, z or i + j + k
    public Vector2 Velocity;
    public Vector2 Force;
    public float angle;
    public float airdrag;
    public float Mass = 1;
    
    public UnityEvent<MyRigidbodyObject> OnCollision = new UnityEvent<MyRigidbodyObject>();
    public void AddForce(Vector2 direction, float force, bool impulse = false)
    {
        if (impulse)
            force *= 1 / 0.02f;
        Force += direction.normalized * force;
    }
    
    public MyCollider collider;

    public void Init()
    {
        Position = transform.position;
    }
    void Awake()
    {
        Init();
        CustomPhysics.AddBody(this);
    }

    private void OnDestroy()
    {
        CustomPhysics.RemoveBody(this);
    }


    public void Interpolate(float t)
    {
       //transform.position += new Vector3(Velocity.x,Velocity.y,0) * t;
    }
}