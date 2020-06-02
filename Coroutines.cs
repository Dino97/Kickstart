using System.Collections;
using UnityEngine;

namespace Kickstart
{
    public static class Coroutines
    {
        public static IEnumerator Translate(Transform obj, Vector3 p1, Vector3 p2, float duration)
        {
            float t = 0.0f;

            while (t < 1.0f)
            {
                t += Time.deltaTime / duration;
                obj.position = Vector3.Lerp(p1, p2, t);

                yield return null;
            }
        }

        public static IEnumerator Rotate(Transform obj, Quaternion r1, Quaternion r2, float duration)
        {
            float t = 0.0f;

            while (t < 1.0f)
            {
                t += Time.deltaTime / duration;
                obj.rotation = Quaternion.Lerp(r1, r2, t);

                yield return null;
            }
        }

        public static IEnumerator Scale(Transform obj, Vector3 s1, Vector3 s2, float duration)
        {
            float t = 0.0f;

            while (t < 1.0f)
            {
                t += Time.deltaTime / duration;
                obj.localScale = Vector3.Lerp(s1, s2, t);

                yield return null;
            }
        }

        public static IEnumerator TranslateLocal(Transform obj, Vector3 p1, Vector3 p2, float duration)
        {
            float t = 0.0f;

            while (t < 1.0f)
            {
                t += Time.deltaTime / duration;
                obj.localPosition = Vector3.Lerp(p1, p2, t);

                yield return null;
            }
        }

        public static IEnumerator RotateLocal(Transform obj, Quaternion r1, Quaternion r2, float duration)
        {
            float t = 0.0f;

            while (t < 1.0f)
            {
                t += Time.deltaTime / duration;
                obj.localRotation = Quaternion.Lerp(r1, r2, t);

                yield return null;
            }
        }
    }
}