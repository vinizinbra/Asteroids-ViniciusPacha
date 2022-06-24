using System;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class UiWindow : MonoBehaviour {

    public UnityEvent onShow = new UnityEvent();
    public UnityEvent onHide = new UnityEvent();

    public virtual void Hide()
    {
        gameObject.SetActive(false);
        onHide.Invoke();

    }
    public virtual void Show()
    {
        gameObject.SetActive(true);
        onShow.Invoke();
    }
    
    public static void Show<T>() where T : UiWindow
    {
        var allScreens = WindowManager.instance.uiWindows;

        bool exists = Enumerable.Any(allScreens, s => s is T);

        if (!exists)
            return;
        foreach (var window in allScreens)
        {
            if (window is T)
            {
                window.Show();
            }
            else
            {
                window.Hide();
            }
        }
    }
    
    public static UiWindow Get<T>() where T : UiWindow
    {
        var allScreens = WindowManager.instance.uiWindows;

        foreach (var window in allScreens)
        {
            if (window is T)
                return window;
        }
        return null;
    }
}
