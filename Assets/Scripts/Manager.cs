using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class Manager<T> : MonoBehaviour where T: Component
{
    private static T _instance;

    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<T>();
                if (_instance == null)
                {
                    GameObject newGo = new GameObject();
                    newGo.name = typeof(T).ToString();
                    _instance = newGo.AddComponent<T>();
                }
            }

            return _instance;
        }
    }
    public virtual void Awake()
    {
        DontDestroyOnLoad(this);
        _instance = this as T;
    }
    
}
