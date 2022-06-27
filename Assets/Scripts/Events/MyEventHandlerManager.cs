using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MyEventHandlerManager : Singleton<MyEventHandlerManager>
{
    public List<MyEventBase> myEvents = new List<MyEventBase>();

    public UnityEvent<MyEventBase> onEvent = new UnityEvent<MyEventBase>();

    void Update()
    {
        foreach (var e in myEvents)
        {
            onEvent.Invoke(e);
        }
        myEvents.Clear();
    }
}
