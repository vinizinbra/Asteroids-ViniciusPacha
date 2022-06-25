using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MyEventHandler : MonoBehaviour
{
    public List<MyEventBase> myEvents = new List<MyEventBase>();

    public UnityEvent<MyEventBase> onEvent;

    public static MyEventHandler Instance;

    void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        foreach (var e in myEvents)
        {
            onEvent.Invoke(e);
        }
        myEvents.Clear();
    }
}
