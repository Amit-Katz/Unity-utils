using Lodash;
using System.Linq;
using UnityEngine;
using System.Collections.Generic;

namespace GameUI
{
    [RequireComponent(typeof(Collider))]
    public class MenuExplorer : MonoBehaviour
    {
        [SerializeField]
        private GameObject hand;

        private List<Interactable> near;
        private Interactable focused;

        void Start() => near = new List<Interactable>();

        void Update()
        {
            SetFocusedComponent();

            if (Input.GetKeyDown(KeyCode.E) && focused)
                focused.Interact(this.hand);
        }

        private void SetFocusedComponent()
        {
            Interactable nearest = GetNearestVisibleInList();

            if (nearest != focused)
            {
                if (focused) focused.IsVisible = false;
                focused = nearest;
                if (focused) focused.IsVisible = true;
            }
        }

        private Interactable GetNearestVisibleInList() => (!near.Any()) ? null :
            near.OrderBy(item => _.Distance(item.transform.position, transform.position))
                .FirstOrDefault(item =>
                    item.enabled && Utils.IsInLightOfSight(item.transform.position));

        void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Interactable menu))
                near.Add(menu);
        }

        void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out Interactable menu))
            {
                near.Remove(menu);
                menu.IsVisible = false;
            }
        }
    }
}