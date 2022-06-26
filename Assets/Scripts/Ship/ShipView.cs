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
        if(PlayerManager.Instance != null)
            PlayerManager.Instance.onChangePlayers.AddListener(UpdateShipView);
        MyEventHandlerManager.Instance.onEvent.AddListener(OnShipDestroyed);

    }

    private void OnShipDestroyed(MyEventBase ev)
    {
        if (ev is OnShipDestroyedEvent)
        {
            if ((ev as OnShipDestroyedEvent).shipObject == ship.rbd)
                DeathFx();
        }
    }

    private void DeathFx()
    {
        explosionFx.UnparentAndPlay();
    }
    void UpdateShipView()
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

        UpdateShipView();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, ship.data.projectilePrefab.data.maxDistance);
    }
}
