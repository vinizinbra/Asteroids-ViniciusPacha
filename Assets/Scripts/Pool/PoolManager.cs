using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PoolManager : Singleton<PoolManager>
{
    public Dictionary<string,Pool> poolDictionary = new Dictionary<string, Pool>();

    public PoolData data;

    protected override void Awake()
    {
        base.Awake();
        Debug.Log("aaa");
        Debug.Log(Instance.ToString());
        foreach (var prefab in data.prefabs)
        {
            Pool p = gameObject.AddComponent<Pool>();
            p.initQuantity = data.initValue;
            p.InitPool(prefab);
            poolDictionary.Add(prefab.ID,p);
        }
    }

    public Entity CreateObjectFromPool(Entity e, Vector2 position, float angle)
    {
        return poolDictionary[e.ID].GetObectFromPool(position,angle);
        
    }
    public Entity DisableObjectFromPool(Entity e)
    {
        return poolDictionary[e.ID].DisableObjectFromPool(e);
        
    }
}
