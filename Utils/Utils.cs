using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace Lodash
{
    public static partial class _
    {
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
                string prefix = depth >= 1 ? Enumerable.Repeat("│     ", depth - 1) + "└─" : "";
                string icon = node.children.Count > 0 ? "▼ " : "O ";
                string str = prefix + icon + node.Value;

                foreach (Node<T> childNode in node.children)
                    str += "\n" + DeepString(childNode, depth + 1);

                return str;
            }
        }
    }
}