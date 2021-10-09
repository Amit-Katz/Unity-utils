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
            label.Initialize("[E] Pick Up");
            label.OnInteract += this.Equip;
        }

        public void Equip(GameObject equipper)
        {
            if (equipper.TryGetComponent<Inventory>(out Inventory inventory))
                inventory.PickItem(this);
        }
    }
}
