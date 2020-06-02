using UnityEngine;

namespace Kickstart
{
    public static class Math
    {
        public static float QuadraticLerp(float a, float b, float c, float t)
        {
            float l1 = Mathf.Lerp(a, b, t);
            float l2 = Mathf.Lerp(b, c, t);
            return Mathf.Lerp(l1, l2, t);
        }

        public static Vector2 QuadraticLerp(Vector2 a, Vector2 b, Vector2 c, float t)
        {
            Vector2 l1 = Vector2.Lerp(a, b, t);
            Vector2 l2 = Vector2.Lerp(b, c, t);
            return Vector2.Lerp(l1, l2, t);
        }

        public static Vector3 QuadraticLerp(Vector3 a, Vector3 b, Vector3 c, float t)
        {
            Vector3 l1 = Vector3.Lerp(a, b, t);
            Vector3 l2 = Vector3.Lerp(b, c, t);
            return Vector3.Lerp(l1, l2, t);
        }
    }
}