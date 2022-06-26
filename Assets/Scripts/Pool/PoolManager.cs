using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class PoolManager : MonoBehaviour
{
    public Dictionary<string,Pool> poolDictionary = new Dictionary<string, Pool>();

    public PoolData data;

    public static PoolManager Instance;
    private void Awake()
    {
        if (PoolManager.Instance != null)
        {
            Destroy(this.gameObject);
            return;
        }

        DontDestroyOnLoad(this);
        Instance = this;
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
