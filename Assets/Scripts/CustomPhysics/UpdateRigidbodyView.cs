using Unity.Mathematics;
using UnityEngine;

namespace CustomPhysics
{
    public class UpdateRigidbodyView : MonoBehaviour
    {
        public MyRigidbodyObject myRigidbodyObject;
        // Start is called before the first frame update
        void Reset()
        {
            myRigidbodyObject = GetComponent<MyRigidbodyObject>();
        }
    
        private void Update()
        {
            transform.position = myRigidbodyObject.Position;
            transform.rotation = quaternion.Euler(0,0,myRigidbodyObject.angle);
        }
    }
}
