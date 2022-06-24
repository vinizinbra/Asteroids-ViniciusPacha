using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class MyRigidbodyObject : MonoBehaviour
{
    public Vector2 Position;
    public Vector2 Velocity;
    public Vector2 Force;
    public float angle;
    public bool isDestroyed;
    public bool isEnabled = true;
    public MyRigidbodyData data;
    public List<MyMonoBehaviour> myComponents = new List<MyMonoBehaviour>();
    public UnityEvent<MyRigidbodyObject> onCollision = new UnityEvent<MyRigidbodyObject>();
    
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
        name = gameObject.name;
    }
    void Awake()
    {
        Init();
        myComponents = GetComponents<MyMonoBehaviour>().ToList();
        MyPhysics.AddBody(this);
    }

    private void OnDestroy()
    {
        MyPhysics.RemoveBody(this);
    }

    private void Update()
    {
        if(isDestroyed)
            Destroy(this.gameObject);
    }

    public void MyDestroy()
    {
        isDestroyed = true;
        MyPhysics.RemoveBody(this);
    }
    public void Interpolate(float t)
    {
       //transform.position += new Vector3(Velocity.x,Velocity.y,0) * t;
    }
}