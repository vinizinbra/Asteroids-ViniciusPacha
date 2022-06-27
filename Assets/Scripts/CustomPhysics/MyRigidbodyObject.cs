using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace CustomPhysics
{
    [RequireComponent(typeof(MyCollider))]
    public class MyRigidbodyObject : MonoBehaviour
    {
        public Vector2 Position;
        public Vector2 Velocity;
        public Vector2 Force;
        public float angle;
        public bool isEnabled = true;
        public MyRigidbodyData data;
        public Controller[] myControllers;
        public UnityEvent<Entity> onCollision = new UnityEvent<Entity>();
    
        public void AddForce(Vector2 direction, float force, bool impulse = false)
        {
            if (impulse)
                force *= 1 / 0.02f;
            Force += direction.normalized * force;
        }
    
        [FormerlySerializedAs("collider")] public MyCollider myCollider;

        public void Init()
        {
            Position = transform.position;
            name = gameObject.name;
        }
        void Awake()
        {
            Init();
            myControllers = GetComponents<Controller>();
        }
    }
}