using System;
using System.Resources;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public string ID;
    public MyRigidbodyObject rbd;
    private void Update()
    {
        if(!rbd.isEnabled)
            gameObject.SetActive(false);
    }

    public virtual void Reset()
    { 
        MyPhysics.RemoveBody(this);
        rbd.Force = Vector2.zero;
        rbd.Velocity = Vector2.zero;
        rbd.angle = 0;

    }

    public void OnEnable()
    {
        MyPhysics.AddBody(this);
    }

    private void OnDisable()
    {
        MyPhysics.RemoveBody(this);
    }
    

}