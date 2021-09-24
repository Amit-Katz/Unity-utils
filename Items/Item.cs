using GameUI;
using UnityEngine;

namespace Items
{
    public class Item : MonoBehaviour
    {
        private Label label;

        private void Start()
        {
            label = gameObject.AddComponent<Label>();
            label.Initialize("[E] Pick Up", FontSize.Big, GameUI.Color.Green, FontStyle.Italic);
            label.OnInteract += this.Equip;
        }

        public void Equip(GameObject visualParent)
        {
            label.IsVisible = false;
            label.enabled = false;

            if (TryGetComponent(out Rigidbody rb))
                rb.isKinematic = true;
            foreach (Collider collider in GetComponents<Collider>())
                collider.enabled = false;

            transform.SetParent(visualParent.transform);

            transform.localPosition = Vector3.zero;
            transform.localEulerAngles = new Vector3(0f, 0f, 180);
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x),
                                       Mathf.Abs(transform.localScale.y),
                                       Mathf.Abs(transform.localScale.z));
        }
    }
}
