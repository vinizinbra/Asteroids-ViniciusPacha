using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class CustomPhysics : MonoBehaviour
{
    const float MAX_DELTA = 0.3f;
    const float FIXED_TIME_STEP = 0.02f;
    private float currentTime;
    private float accumulator;
    public float gravity = 10;
    private Thread physicsThread;
    void Start()
    {
        physicsThread = new Thread( PhysicsLoop);
        physicsThread.Start();
    }
  

    public static List<MyRigidbodyObject> objectList = new List<MyRigidbodyObject>();


    public static void AddBody(MyRigidbodyObject obj)
    {
        objectList.Add(obj);
    }
    public static void RemoveBody(MyRigidbodyObject obj)
    {
        objectList.Add(obj);
    }
   
    void PhysicsLoop()
    {
        float realtimeSinceStartup = 0;
        while (true)
        {
            float newTime = realtimeSinceStartup;
            float frameTime = newTime - currentTime;

            if (frameTime > MAX_DELTA) frameTime = MAX_DELTA;
            currentTime = newTime;

            accumulator += frameTime * 1;

            // Fixed update loop - note it can run multiple times per frame
            while (accumulator >= FIXED_TIME_STEP * 1)
            {
                float step = FIXED_TIME_STEP * 1;
                //if(OnPreStep != null) OnPreStep();         
                Step(step);
                //if(OnPostStep != null) OnPostStep();
                accumulator -= step;
            }

            float alpha = accumulator / (FIXED_TIME_STEP * 1);
        
            foreach(var body in objectList)
            {
                body.Interpolate(alpha);
            }
            
            Thread.Sleep((int)(FIXED_TIME_STEP * 1000));
            realtimeSinceStartup += FIXED_TIME_STEP;
            
        }
        
        
    }

    private void OnApplicationQuit()
    {
        physicsThread.Abort();
    }

    public void Step(float dt)
    {
        ResolveCollisions(dt);
        for (int i = 0; i < objectList.Count; i++)
        {
            var body = objectList[i];
            var frictionVector = -body.Velocity * body.airdrag * dt;
            body.Velocity += frictionVector;
            body.Velocity += body.Force / body.Mass * dt;
            body.Position += body.Velocity * dt;

            body.Force = Vector3.zero; // reset net force at the end
        }
    }

    public void ResolveCollisions(float dt)
    {
        List<MyCollision> collisions = new List<MyCollision>();

        for (int i = 0; i < objectList.Count; i++)
        {
            var objA = objectList[i];
            for (int j = 0; i < objectList.Count; j++)
            {
                var objB = objectList[j];
                
                if (objA == objB) break;
                bool collided = objA.collider.CheckCollision(objA, objB);
                
                if (collided)
                {
                    var c = new MyCollision();
                    c.ObjA = objA;
                    c.ObjB = objB;
                    collisions.Add(c);
                }
            }
        }

        SendCollisionsCallbacks(collisions);
    }

    private void SendCollisionsCallbacks(List<MyCollision> collisions)
    {
        foreach (var c in collisions)
        {
            c.ObjA.OnCollision.Invoke(c.ObjB);
            c.ObjB.OnCollision.Invoke(c.ObjA);
        }
    }
}
