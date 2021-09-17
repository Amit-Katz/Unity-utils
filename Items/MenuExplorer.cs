using Lodash;
using System.Linq;
using UnityEngine;
using System.Collections.Generic;

namespace GameUI
{
    public class MenuExplorer : MonoBehaviour
    {
        private List<InteractableComponent> near;
        private InteractableComponent focused;

        void Start()
        {
            near = new List<InteractableComponent>();
        }

        void Update()
        {
            SetFocusedComponent();

            if (Input.GetKeyDown(KeyCode.E) && focused)
                focused.Interact();
        }

        private void SetFocusedComponent()
        {
            InteractableComponent nearest = GetNearestVisibleTransformInList();

            if (nearest != focused)
            {
                if (focused) focused.IsVisible = false;
                focused = nearest;
                if (focused) focused.IsVisible = true;
            }
        }

        private InteractableComponent GetNearestVisibleTransformInList()
        {
            if (near.Count > 0)
                return near.OrderBy(item => _.Distance(item.transform.position, transform.position))
                    .FirstOrDefault((item) => item.enabled &&
                    Utils.IsInLightOfSight(item.transform.position));

            return null;
        }

        void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out InteractableComponent component))
                near.Add(component);
        }

        void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out InteractableComponent component))
            {
                near.Remove(component);
                component.IsVisible = false;
            }
        }
    }
}