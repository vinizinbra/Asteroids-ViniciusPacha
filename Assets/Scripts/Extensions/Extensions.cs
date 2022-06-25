
using System;
using UnityEngine;

public static class Extensions
{
    // Extension method which marshals events back onto the main thread
    public static Vector3 ToVector3(this Vector2 vec2)
    {
        return new Vector3(vec2.x, vec2.y);
    }
    
    public static Vector2 Rotate(this Vector2 v, float delta) {
        return new Vector2(
            v.x * Mathf.Cos(delta) - v.y * Mathf.Sin(delta),
            v.x * Mathf.Sin(delta) + v.y * Mathf.Cos(delta)
        );
    }
    public static ParticleSystem UnparentAndPlay(this ParticleSystem particleSystem)
    {
        particleSystem.transform.parent = null;
        particleSystem.Play();
        return particleSystem;
    }

}
