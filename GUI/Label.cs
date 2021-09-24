using Lodash;
using UnityEngine;

namespace GameUI
{
    public sealed class Label : Interactable
    {
        private UnityEngine.UI.Text textElement;

        public override Vector3 Position
        {
            get => textElement.transform.position;
            set { textElement.transform.position = value; }
        }

        public override bool IsVisible
        {
            get => enabled && textElement.enabled;
            set { textElement.enabled = value; }
        }

        public void Initialize(string text = "",
                                FontSize fontSize = FontSize.Normal,
                                GameUI.Color color = GameUI.Color.White,
                                FontStyle style = FontStyle.Normal)
        {
            textElement = textElement ?? MenuManager.Instance.CreateTextElement();
            textElement.text = text;
            textElement.fontSize = (int)fontSize;
            textElement.color = Utils.ColorMap(color);
            textElement.fontStyle = style;
        }

        private void Start() => IsVisible = false;

        private void Update() => Position = _.WorldToScreenPoint(transform.position);
    }
}