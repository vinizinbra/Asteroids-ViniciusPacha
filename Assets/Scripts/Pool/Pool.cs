using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Pool : MonoBehaviour
{
    public Entity prefab;
    public int initQuantity = 2;
    public List<Entity> pooledObjects = new List<Entity>();

    public void InitPool(Entity prefab)
    {
        this.prefab = prefab;

        for (int i = 0; i < initQuantity; i++)
        {
            CreateObjectInPool();
        }
    }

    Entity CreateObjectInPool()
    {
        var o = Instantiate(prefab,transform);
        pooledObjects.Add(o);
        o.rbd.isEnabled = false;
        o.gameObject.SetActive(false);
        return o;
    }
    void IncreasePool()
    {
        initQuantity *= 2;
        for (int i = pooledObjects.Count; i < initQuantity; i++)
        {
            CreateObjectInPool();
        }
    }
    public Entity GetObectFromPool(Vector2 position,float angle)
    {
        var e = pooledObjects.FirstOrDefault(x => !x.rbd.isEnabled);
        if (e == null)
        {
            IncreasePool();
            //Debug.Break();
            e = pooledObjects.FirstOrDefault(x => !x.rbd.isEnabled);
        }

        e.transform.position = position;
        e.rbd.Position = position;
        e.rbd.Force = Vector2.zero;
        e.rbd.angle = angle;
        e.rbd.isEnabled = true;
        e.Reset();
        e.gameObject.SetActive(true);
        return e;
    }

    public Entity DisableObjectFromPool(Entity e)
    {
        e.rbd.isEnabled = false;
        e.Reset();
        return e;
    }
}
