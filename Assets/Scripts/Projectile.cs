using System;
using Unity.VisualScripting;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public MyRigidbodyObject rbd;
    public bool alive = true;
    private void Awake()
    {
        rbd.OnCollision.AddListener( OnCollision );
    }

    private void OnDestroy()
    {
        rbd.OnCollision.RemoveListener(OnCollision);
    }

    private void OnCollision(MyRigidbodyObject other)
    {
        if (other.collider.tag == MyCollider.Tag.ASTEROID)
        {
            CustomPhysics.objectList.Remove(this.rbd);
            CustomPhysics.objectList.Remove(other);
        }
    }

    private void Update()
    {
        if (!CustomPhysics.objectList.Contains(rbd))
        {
            Debug.Break();
            Destroy(gameObject);
        }
    }
}