using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MyEventHandlerManager : Singleton<MyEventHandlerManager>
{
    public static List<MyEventBase> MyEvents = new List<MyEventBase>();
    public static UnityEvent<MyEventBase> OnEvent = new UnityEvent<MyEventBase>();

    void Update()
    {
        foreach (var e in MyEvents)
        {
            OnEvent.Invoke(e);
        }
        MyEvents.Clear();
    }
}
