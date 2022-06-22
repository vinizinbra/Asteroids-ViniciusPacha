using System;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public MyRigidbodyObject rbd;

    private void Awake()
    {
        rbd.OnCollision.AddListener(OnCollision);
    }

    private void OnDestroy()
    {
        rbd.OnCollision.RemoveListener(OnCollision);
    }

    private void OnCollision(MyRigidbodyObject other)
    {
        if (other.collider.tag == MyCollider.Tag.ASTEROID)
        {
            Destroy(this.gameObject);
        }
    }
    
}