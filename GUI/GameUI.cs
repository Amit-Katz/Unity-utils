using System;
using Lodash;
using UnityEngine;

namespace GameUI
{
    #region Utils
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
    #endregion
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

    interface IComponent
    {
        Vector3 Position { get; set; }
        bool IsVisible { get; set; }
    }

    public abstract class InteractableComponent : MonoBehaviour, IComponent
    {
        public virtual Vector3 Position { get => transform.position; set { transform.position = value; } }
        public virtual bool IsVisible { get; set; }
        public virtual void Interact() => throw new NotImplementedException();
    }
}
