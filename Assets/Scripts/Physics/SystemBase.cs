using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SystemBase : MonoBehaviour
{
    private bool _isQuitting;

    public void OnApplicationQuit()
    {
        _isQuitting = true;
    }

    public virtual void MyFixedUpdate()
    {
        
    }
}
