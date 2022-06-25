using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MyMonoBehaviour : MonoBehaviour
{
    private bool _isQuitting;

    public virtual void SafeOnDestroy()
    {
        
    }
    
    private void OnDestroy()
    {
        if (_isQuitting)
            return;
        SafeOnDestroy();
    }

    public void OnApplicationQuit()
    {
        _isQuitting = true;
    }

    // Update is called once per frame
    public virtual void MyFixedUpdate()
    {
        
    }
}
