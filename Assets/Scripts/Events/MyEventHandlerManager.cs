using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MyEventHandlerManager : MonoBehaviour
{
    public List<MyEventBase> myEvents = new List<MyEventBase>();

    public UnityEvent<MyEventBase> onEvent = new UnityEvent<MyEventBase>();

    public static MyEventHandlerManager Instance;
    private void Awake()
    {
        if (MyEventHandlerManager.Instance != null)
        {
            Destroy(this.gameObject);
            return;
        }        
        
        DontDestroyOnLoad(this);
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
