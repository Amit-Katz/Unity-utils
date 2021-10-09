using UnityEngine;
using System.Collections.Generic;

namespace Items
{
    public class Container : MonoBehaviour
    {
        HashSet<Item> items;

        protected void Start() => this.items = new HashSet<Item>();
        public void Add(Item item) => this.items.Add(item);
        public void Remove(Item item) => this.items.Remove(item);
    }

    public class Inventory : Container
    {
        private Hand[] hands;

        protected new void Start()
        {
            base.Start();
            this.hands = GetComponents<Hand>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                DropItem();
            }
        }

        /// <returns>Whether the item was picked up.</returns>
        public bool PickItem(Item item)
        {
            foreach (Hand hand in this.hands)
                if (!hand.Item)
                {
                    hand.EquipItem(item.transform);
                    return true;
                }

            return false;
        }

        /// <returns>Whether an item was dropped.</returns>
        public bool DropItem()
        {
            foreach (Hand hand in this.hands)
                if (hand.Item)
                {
                    hand.UnequipItem();
                    return true;
                }

            return false;
        }
    }
}
