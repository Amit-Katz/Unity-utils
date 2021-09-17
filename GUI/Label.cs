using Items;
using Lodash;
using UnityEngine;
using UnityEngine.UI;

namespace GameUI
{
    public class Label : InteractableComponent
    {
        [SerializeField]
        private string Text = "";
        [SerializeField]
        private GameUI.Color color = GameUI.Color.White;
        [SerializeField]
        private FontSize size = FontSize.Normal;
        [SerializeField]
        private FontStyle style = FontStyle.Normal;

        private Text textElement;

        private void Start()
        {
            textElement = MenuManager.Instance.CreateTextElement();
            textElement.text = Text;
            textElement.fontSize = (int)size;
            textElement.color = Utils.ColorMap(color);
            textElement.fontStyle = style;
            IsVisible = false;
        }

        private void Update() => Position = _.WorldToScreenPoint(transform.position);

        public override void Interact()
        {
            foreach (IInteractable interactable in GetComponents<IInteractable>())
                interactable.Interact(this);
        }

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
    }
}