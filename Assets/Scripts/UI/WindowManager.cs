using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowManager : MonoBehaviour
{
    public static WindowManager instance; 
    public UiWindow[] uiWindows; 
    void Awake()
    {
        instance = this;
        uiWindows = GetComponentsInChildren<UiWindow>(true);
        UiWindow.Show<MenuWindow>();
    }

}
