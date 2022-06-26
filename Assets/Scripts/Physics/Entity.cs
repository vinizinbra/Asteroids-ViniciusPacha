using System;
using System.Resources;
using Unity.VisualScripting;
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
        rbd.Force = Vector2.zero;
        rbd.Velocity = Vector2.zero;
        rbd.angle = 0;
    }

    public void OnEnable()
    {
        MyPhysics.AddBody(this);
    }

    public void OnDisable()
    {
        if(GameManager.Instance.currentGameState != GameManager.GameState.INGAME)
            MyPhysics.RemoveBody(this);

        rbd.isEnabled = false;
    }
}