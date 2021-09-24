using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;

namespace Lodash
{
    public static class _
    {
        /// <returns>The distance between two positions.</returns>
        public static float Distance(Vector2 first, Vector2 second) => Vector2.Distance(first, second);
        /// <returns>The distance between two positions.</returns>
        public static float Distance(Vector3 first, Vector3 second) => Vector3.Distance(first, second);
        /// <returns>The horizontal input axis in raw form.</returns>
        public static float InputXRaw() => Input.GetAxisRaw("Horizontal");
        /// <returns>The vertical input axis in raw form.</returns>
        public static float InputYRaw() => Input.GetAxisRaw("Vertical");
        /// <returns>The horizontal input axis.</returns>
        public static float InputX() => Input.GetAxis("Horizontal");
        /// <returns>The vertical input axis.</returns>
        public static float InputY() => Input.GetAxis("Vertical");
        /// <returns>The direction of 'second' relative to 'first'.</returns>
        public static Vector2 Direction(Vector2 first, Vector2 second) => (first - second).normalized;
        /// <returns>The direction of 'second' relative to 'first'.</returns>
        public static Vector3 Direction(Vector3 first, Vector3 second) => (first - second).normalized;
        /// <returns>The mouse world position.</returns>
        public static Vector3 MouseWorldPosition() => Camera.main.ScreenToWorldPoint(Input.mousePosition);
        /// <returns>Whether the left mouse button is being pressed.</returns>
        public static bool IsMouseLeftPressed() => Input.GetMouseButton(0);
        /// <returns>Whether the right mouse button is being pressed.</returns>
        public static bool IsMouseRightPressed() => Input.GetMouseButton(1);
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

        /// <summary>
        /// Makes 'looker' rotate towards 'target'.
        /// </summary>
        public static void LookAt(Transform looker, Vector2 target)
        {
            Vector2 direction = _.Direction((Vector2)looker.position, target);
            looker.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 90);
        }
        #region LookAt
        public static void LookAt(GameObject looker, Vector2 target) =>
            LookAt(looker.transform, target);
        public static void LookAt(GameObject looker, GameObject target) =>
            LookAt(looker.transform, target.transform.position);
        public static void LookAt(Transform looker, Transform target) =>
            LookAt(looker, target.position);
        public static void LookAt(Transform looker, GameObject target) =>
            LookAt(looker, target.transform.position);
        #endregion

        /// <param name="str">The string to repeat</param>
        /// <param name="times">How many times to repeat the string</param>
        /// <returns>'str' repeated 'times' times.</returns>
        public static string Times(string str, int times) => string.Join("", Enumerable.Repeat(str, times));
        #region Times
        /// <param name="character">The char to repeat</param>
        /// <param name="times">How many times to repeat the char</param>
        /// <returns>'character' repeated 'times' times.</returns>
        public static string Times(char character, int times) => new string(character, times);
        #endregion

        /// <summary>
        /// A Generic tree node
        /// </summary>
        public class Node<T> where T : IComparable, IEnumerable
        {
            public T Value;
            public List<Node<T>> children;

            public Node(T value)
            {
                Value = value;
                children = new List<Node<T>>();

                foreach (T child in value)
                    Add(child);
            }

            public Node<T> Add(T value)
            {
                Node<T> node = new Node<T>(value);
                children.Add(node);
                return node;
            }

            public void Add(Node<T> node) => children.Add(node);

            public T[] GetChildrenValues() => children.Select(child => child.Value).ToArray();

            public override string ToString() => DeepString(this, 0);

            private string DeepString(Node<T> node, int depth)
            {
                string prefix = depth >= 1 ? _.Times("│     ", depth - 1) + "└─" : "";
                string icon = node.children.Count > 0 ? "▼ " : "O ";
                string str = prefix + icon + node.Value;

                foreach (Node<T> childNode in node.children)
                    str += "\n" + DeepString(childNode, depth + 1);

                return str;
            }
        }
    }
}