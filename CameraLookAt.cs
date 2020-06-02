using UnityEngine;

namespace Kickstart
{
    public class CameraLookAt : MonoBehaviour
    {
        public float damping = 0.5f;
        public float rotationSpeed = 15.0f;

        private Vector3 _startRotation;
        private Quaternion _targetRotation;

        private const int MIN_DAMPING = 0.1f;



        private void Start()
        {
            _startRotation = transform.localRotation.eulerAngles;
        }

        private void Update()
        {
            if (Input.GetMouseButton(0))
            {
                Vector2 dir = new Vector2(Screen.height / 2 - Input.mousePosition.y, Screen.width / 2 - Input.mousePosition.x);
                dir /= (Screen.width * Mathf.Max(MIN_DAMPING, damping));
                _targetRotation = Quaternion.Euler((Vector2)_startRotation + new Vector2(dir.x, -dir.y));
            }
            else
            {
                _targetRotation = Quaternion.Euler(_startRotation);
            }

            float singleStep = rotationSpeed * Time.deltaTime;
            transform.localRotation = Quaternion.RotateTowards(transform.localRotation, _targetRotation, singleStep);
        }
    }
}