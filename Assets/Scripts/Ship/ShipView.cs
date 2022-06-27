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
    public ParticleSystem propulsionFx;
    public ParticleSystem explosionFx;

    void Start()
    {
        MyEventHandlerManager.OnEvent.AddListener(OnShipHit);

    }

    private void OnShipHit(MyEventBase ev)
    {
        if (ev is OnShipHitEvent)
        {
            var ship = (ev as OnShipHitEvent).shipObject as Ship;
            if (ship == this.ship)
            {
                if(ship.currentLife <= 0)
                    DeathFx();
            }
        }
    }

    private void DeathFx()
    {
        UpdateShipView();
        explosionFx.transform.position = transform.position;
        explosionFx.UnparentAndPlay();
    }
    public void UpdateShipView()
    {
        gameObject.SetActive(ship.currentLife > 0 && ship.owner.IsConnected);
    }
    private void Update()
    {
        Color c = Color.white;
        c.a = ship.collisionDelay > 0 ? 0.3f : 1;
        sprite.color = c;
        if(!propulsionFx.isPlaying && ship.isThrusting)
            propulsionFx.Play();
        else if(!ship.isThrusting)
        {
            propulsionFx.Stop();
        }
    }
}
