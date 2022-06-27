using System.Collections.Generic;
using CustomPhysics;
using UnityEngine;

namespace Pool
{
    public class PoolManager : Singleton<PoolManager>
    {
        public Dictionary<string,global::Pool.Pool> poolDictionary = new Dictionary<string, Pool>();

        public PoolData data;

        protected override void Awake()
        {
            base.Awake();
            foreach (var prefab in data.prefabs)
            {
                global::Pool.Pool p = gameObject.AddComponent<global::Pool.Pool>();
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
}
