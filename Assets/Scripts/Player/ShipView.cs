using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class ShipView : MonoBehaviour
{
    public Ship ship;
    public SpriteRenderer sprite;
    [FormerlySerializedAs("particle")] public ParticleSystem propulsionFx;

    private void Update()
    {
        Color c = Color.white;
        c.a = ship.collisionDelay > 0 ? 0.3f : 1;
        sprite.color = c;
        if(!propulsionFx.isPlaying && ship.accelerate)
            propulsionFx.Play();
        else if(!ship.accelerate)
        {
            propulsionFx.Stop();
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, ship.data.projectilePrefab.data.maxDistance);
    }
}
