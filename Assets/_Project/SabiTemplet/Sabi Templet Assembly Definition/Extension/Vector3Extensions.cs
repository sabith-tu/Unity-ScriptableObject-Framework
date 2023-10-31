using UnityEngine;

namespace SABI.Extension
{
    public static class Vector3Extensions
    {
        // 1 axis
        public static Vector3 With(this Vector3 vector, int axis, float value)
        {
            vector[axis] = value;
            return vector;
        }

        public static Vector3 WithX(this Vector3 vector, float x) => With(vector, 0, x);
        public static Vector3 WithY(this Vector3 vector, float y) => With(vector, 1, y);
        public static Vector3 WithZ(this Vector3 vector, float z) => With(vector, 2, z);

        // 2 axis

        public static Vector3 With(this Vector3 vector, int axis1, float value1, int axis2, float value2)
        {
            vector[axis1] = value1;
            vector[axis2] = value2;

            return vector;
        }

        public static Vector3 WithXY(this Vector3 vector, float x, float y) => With(vector, 0, x, 1, y);
        public static Vector3 WithXY(this Vector3 vector, Vector2 value) => With(vector, 0, value.x, 1, value.y);
        public static Vector3 WithXZ(this Vector3 vector, float x, float z) => With(vector, 0, x, 2, z);
        public static Vector3 WithXZ(this Vector3 vector, Vector2 value) => With(vector, 0, value.x, 2, value.y);
        public static Vector3 WithYZ(this Vector3 vector, float y, float z) => With(vector, 1, y, 2, z);
        public static Vector3 WithYZ(this Vector3 vector, Vector2 value) => With(vector, 1, value.x, 2, value.y);

        // 3 axis

        public static Vector3 WithXYZ(this Vector3 vector, float x, float y, float z)
        {
            vector[0] = x;
            vector[1] = y;
            vector[2] = z;
            return vector;
        }

        // clamp

        public static Vector3 Clamp(this Vector3 vector, float min, float max)
        {
            return new Vector3(
                Mathf.Clamp(vector.x, min, max),
                Mathf.Clamp(vector.y, min, max),
                Mathf.Clamp(vector.z, min, max));
        }

        public static Vector3 Clamp01(this Vector3 vector)
        {
            return new Vector3(
                Mathf.Clamp01(vector.x),
                Mathf.Clamp01(vector.y),
                Mathf.Clamp01(vector.z));
        }

        public static Vector3 Clamp(this Vector3 vector, Vector3 min, Vector3 max)
        {
            return new Vector3(
                Mathf.Clamp(vector.x, min.x, max.x),
                Mathf.Clamp(vector.y, min.y, max.y),
                Mathf.Clamp(vector.z, min.z, max.z));
        }
    }
}