using UnityEngine;

namespace Kickstart
{
    public class RotateOverTime : MonoBehaviour
    {
        public float speed = 5.0f;
        public Vector3 axis = Vector3.up;



        void Update()
        {
            transform.Rotate(axis * speed * Time.deltaTime);
        }
    }
}