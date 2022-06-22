using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    public PlayerConfigAsset config;
    
    public MyPlayerInput input;
    public MyRigidbodyObject rbd;
    public Projectile projectilePrefab;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (input.input.right)
            rbd.angle -= config.rotationSpeed*Time.deltaTime;
        if (input.input.left)
            rbd.angle += config.rotationSpeed*Time.deltaTime;
        if (input.input.up)
            rbd.AddForce(transform.right,config.propulsionSpeed);;
        if (input.input.space)
            CreateProjectile();

    }

    void CreateProjectile()
    {
        var go = Instantiate(projectilePrefab, transform.position,transform.rotation);
        go.rbd.AddForce(transform.right,config.shootForce,true);
        Destroy(go.gameObject,2);
    }
}