using UnityEngine;

namespace Lodash
{
    public static partial class _
    {
        /// <summary>The current mouse scroll delta.</summary>
        public static Vector2 MouseScrollDelta => Input.mouseScrollDelta;

        /// <returns>The horizontal input axis in raw form.</returns>
        public static float InputXRaw() => Input.GetAxisRaw("Horizontal");

        /// <returns>The vertical input axis in raw form.</returns>
        public static float InputYRaw() => Input.GetAxisRaw("Vertical");

        /// <returns>The horizontal input axis.</returns>
        public static float InputX() => Input.GetAxis("Horizontal");

        /// <returns>The vertical input axis.</returns>
        public static float InputY() => Input.GetAxis("Vertical");

        /// <returns>Whether the left mouse button has been pressed.</returns>
        public static bool IsMouseLeftPressed() => Input.GetMouseButton(0);

        /// <returns>Whether the right mouse button has been pressed.</returns>
        public static bool IsMouseRightPressed() => Input.GetMouseButton(1);

        /// <returns>Whether the middle mouse button has been pressed.</returns>
        public static bool IsMouseMiddlePressed() => Input.GetMouseButton(2);
    }
}