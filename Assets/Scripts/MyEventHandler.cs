using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyEventHandler : MonoBehaviour
{
    public static MyEventHandler Instance;
    public List<MyCollision> collisionEvent = new List<MyCollision>();
    void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var c in collisionEvent)
        {
            c.ObjA.onCollision.Invoke(c.ObjB);
            c.ObjB.onCollision.Invoke(c.ObjA);
        }
    }
}
