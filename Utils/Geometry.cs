using UnityEngine;

namespace Lodash
{
    public static partial class _
    {
        /// <returns>The distance between two positions.</returns>
        public static float Distance(Vector2 first, Vector2 second) => Vector2.Distance(first, second);

        /// <returns>The distance between two positions.</returns>
        public static float Distance(Vector3 first, Vector3 second) => Vector3.Distance(first, second);

        /// <returns>The direction of 'second' relative to 'first'.</returns>
        public static Vector2 Direction(Vector2 first, Vector2 second) => (first - second).normalized;

        /// <returns>The direction of 'second' relative to 'first'.</returns>
        public static Vector3 Direction(Vector3 first, Vector3 second) => (first - second).normalized;

        /// <returns>The mouse world position.</returns>
        public static Vector3 MouseWorldPosition() => Camera.main.ScreenToWorldPoint(Input.mousePosition);

        /// <returns>The world point projected to screen.</returns>
        public static Vector3 WorldToScreenPoint(Vector3 worldPoint) =>
            Camera.main.WorldToScreenPoint(worldPoint);

        /// <returns>A ray going through a world point.</returns>
        public static Ray WorldPointToRay(Vector3 worldPoint) =>
            Camera.main.ScreenPointToRay(Camera.main.WorldToScreenPoint(worldPoint));

        /// <returns>The mouse world poision using Raycasting</returns>
        public static Vector3 MouseWorldPositionRaycast()
        {
            Plane plane = new Plane(Vector3.up, 0);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            return plane.Raycast(ray, out float distance) ? ray.GetPoint(distance) : Vector3.zero;
        }

        /// <summary>Makes 'looker' rotate towards 'target'.</summary>
        public static void LookAt(Transform looker, Vector2 target)
        {
            Vector2 direction = _.Direction((Vector2)looker.position, target);
            looker.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 90);
        }
    }
}