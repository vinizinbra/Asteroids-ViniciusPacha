
using System;
using UnityEngine;

public static class Extensions
{
    // Extension method which marshals events back onto the main thread
    public static Vector3 ToVector3(this Vector2 vec2)
    {
        return new Vector3(vec2.x, vec2.y);
    }
    

}
