using GameUI;
using UnityEngine;

namespace Items
{
    interface IInteractable
    {
        void Interact(InteractableComponent component);
    }

    interface IPickable
    {
        bool IsPickable { get; set; }
    }

    public class Item : MonoBehaviour, IPickable, IInteractable
    {
        public bool IsPickable { get; set; }

        public void Interact(InteractableComponent component)
        {
            component.IsVisible = false;
            component.enabled = false;
            //transform.localPosition = Vector3.zero;
            //if (TryGetComponent(out Rigidbody rb)) rb.isKinematic = true;
            //foreach (Collider collider in GetComponents<Collider>())
            //    collider.enabled = false;
            //SetParent(hand);
            //transform.localEulerAngles = new Vector3(0f, 0f, 180);
            //transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x),
            //                            Mathf.Abs(transform.localScale.y),
            //                            Mathf.Abs(transform.localScale.z));
        }
    }
}
