using Lodash;
using UnityEngine;

namespace GameUI
{
    static class Utils
    {
        public static UnityEngine.Color ColorMap(Color color) => color switch
        {
            Color.White => new UnityEngine.Color(1, 1, 1),
            Color.Red => new UnityEngine.Color(1, 0, 0),
            Color.Yellow => new UnityEngine.Color(1, 1, 0),
            Color.Green => new UnityEngine.Color(0.3807706f, 1, 0.3404236f),
            Color.Blue => new UnityEngine.Color(0.3411765f, 0.6900184f, 1),
            Color.Purple => new UnityEngine.Color(1, 0.355f, 1),
            Color.Gray => new UnityEngine.Color(0.2641509f, 0.2641509f, 0.2641509f),
            _ => ColorMap(Color.White),
        };

        public static bool IsInLightOfSight(Vector3 worldPoint) =>
            Physics.Raycast(_.WorldPointToRay(worldPoint), out RaycastHit hit, 20f) &&
            hit.transform.gameObject.layer == 0;
    }

    public enum Color
    {
        White,
        Red,
        Yellow,
        Green,
        Blue,
        Purple,
        Gray
    }

    public enum FontSize
    {
        Small = 12,
        Normal = 18,
        Big = 30,
        Huge = 45,
    }

    interface IMenu
    {
        /// <summary>
        /// The world position of the component.
        /// </summary>
        Vector3 Position { get; set; }
        /// <summary>
        /// Whether the component is visually enabled.
        /// </summary>
        bool IsVisible { get; set; }
    }

    public delegate void MenuInteractionEvent(GameObject invoker);

    public abstract class Interactable : MonoBehaviour, IMenu
    {
        public event MenuInteractionEvent OnInteract;
        public virtual Vector3 Position { get => transform.position; set { transform.position = value; } }
        public virtual bool IsVisible { get; set; }
        public void Interact(GameObject invoker) => this.OnInteract?.Invoke(invoker);
    }
}
