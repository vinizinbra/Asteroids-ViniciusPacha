using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class MyPhysics : MonoBehaviour
{
    public const float FIXED_TIME_STEP = 0.02f;
    private float _currentTime;
    public MapData mapConfig;
    private Thread _physicsThread;
    
    public static List<Entity> objectList = new List<Entity>();
    public int count;
    void Start()
    {
        GameManager.Instance.onGameStarted.AddListener(StartSimulation);
        GameManager.Instance.onGameRestart.AddListener(StopSimulation);
    }

    private void OnDestroy()
    {
        StopSimulation();
        GameManager.Instance.onGameStarted.RemoveListener(StartSimulation);
        GameManager.Instance.onGameRestart.RemoveListener(StopSimulation);
    }

    public static void AddBody(Entity obj)
    {
        objectList.Add(obj);
    }
    public static void RemoveBody(Entity obj)
    {
        objectList.Remove(obj);
    }

    private void Update()
    {
        count = objectList.Count;
    }
    
    void PhysicsLoop()
    {
        count = objectList.Count;
        int frame = 0;
        while (true)
        {
            float step = FIXED_TIME_STEP * 1;
            Step(step);
            Thread.Sleep((int)(FIXED_TIME_STEP * 1000));
        }
    }

    private void OnApplicationQuit()
    {
        if(_physicsThread != null)
            _physicsThread.Abort();
    }

    public void StopSimulation()
    {
        foreach (var o in objectList)
        {
            if (o is not Ship)
                o.rbd.isEnabled = false;
        }
        CleanObjects();
        
        if(_physicsThread != null)
            _physicsThread.Abort();
    }
    public void StartSimulation()
    {
        _currentTime = 0;
        _physicsThread = new Thread( PhysicsLoop);
        _physicsThread.Start();
        
    }
    
    public void Step(float dt)
    {
        for (int i = 0; i < objectList.Count; i++)
        {
            var body = objectList[i].rbd;
            
            if (!body.isEnabled) continue;
            
            var frictionVector = -body.Velocity * body.data.airdrag * dt;
            body.Velocity += frictionVector;
            body.Velocity += body.Force / body.data.mass * dt;
            body.Position += body.Velocity * dt;
            
            if (body.Position.x > mapConfig.gameArea.x)
                body.Position.x -= mapConfig.gameArea.x * 2;
            else if (body.Position.x < -mapConfig.gameArea.x)
                body.Position.x += mapConfig.gameArea.x * 2;
            else if (body.Position.y < -mapConfig.gameArea.y)
                body.Position.y += mapConfig.gameArea.y * 2;
            else if (body.Position.y > mapConfig.gameArea.y)
                body.Position.y -= mapConfig.gameArea.y * 2;

            body.Force = Vector3.zero; // reset net force at the end
            for(int j = 0; j < body.myControllers.Length;j++)
                body.myControllers[j].MyFixedUpdate();
        }

        ResolveCollisions();
        CleanObjects();
        Debug.Log("ThreadRunning");
    }

    public void CleanObjects()
    {
        for (int i = objectList.Count-1; i >= 0 ; i-- )
        {
            if (!objectList[i].rbd.isEnabled)
            {
                objectList.Remove(objectList[i]);
            }
        }
    }
    public void ResolveCollisions()
    {
        List<MyCollision> collisions = new List<MyCollision>();

        for (int i = 0; i < objectList.Count; i++)
        {
            var objA = objectList[i];
            
            if (!objA.rbd.isEnabled) continue;
            
            for (int j = 0; i < objectList.Count; j++)
            {
                var objB = objectList[j];
                if (!objB.rbd.isEnabled) continue;

                if (objA == objB) break;
                
                bool collided = objA.rbd.collider.CheckCollision(objA, objB);
                
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
            c.ObjA.rbd.onCollision.Invoke(c.ObjB);
            c.ObjB.rbd.onCollision.Invoke(c.ObjA);
        }
    }
}
