using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class ShipView : MonoBehaviour
{
    public MyRigidbodyObject myRigidbodyObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    private void Update()
    {
        transform.position = myRigidbodyObject.Position;
        transform.rotation = quaternion.Euler(0,0,myRigidbodyObject.angle);
    }
}
