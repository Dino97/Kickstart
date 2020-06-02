using UnityEngine;

namespace Kickstart
{
    public class CameraSway : MonoBehaviour
    {
        public float xDamping = 5.0f;
        public float yDamping = 5.0f;
        public float speed = 10.0f;

        private Vector3 _startPosition;
        private Vector3 _targetPosition;

        private const int MIN_DAMPING = 0.1f;



        private void Start()
        {
            _startPosition = transform.localPosition;
        }

        private void Update()
        {
            if (Input.GetMouseButton(0))
            {
                Vector2 dir = new Vector2(Input.mousePosition.x - Screen.width / 2, Input.mousePosition.y - Screen.height / 2);
                dir.x /= (Screen.width * Mathf.Max(MIN_DAMPING, xDamping));
                dir.y /= (Screen.width * Mathf.Max(MIN_DAMPING, yDamping));
                _targetPosition = _startPosition + new Vector3(dir.x, 0, dir.y);
            }
            else
            {
                _targetPosition = _startPosition;
            }

            float singleStep = speed * Time.deltaTime;
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, _targetPosition, singleStep);
        }
    }
}