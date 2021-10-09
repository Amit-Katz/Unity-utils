using Lodash;
using UnityEngine;
using UnityEngine.U2D.IK;

[RequireComponent(typeof(Movement))]
public class Hand : MonoBehaviour
{
    [SerializeField]
    private LimbSolver2D solver2D;
    [SerializeField]
    private Transform target;
    [SerializeField]
    private Transform visualParent;

    private float Weight
    {
        get => solver2D.weight;
        set { solver2D.weight = value; }
    }

    private Movement movement;
    public Transform Item { get; protected set; }

    void Start() => movement = GetComponent<Movement>();

    void Update()
    {
        bool isAiming = _.IsMouseRightPressed();
        movement.isFocused = isAiming;

        if (Item && isAiming)
        {
            Aim();
            Weight = Weight > 0.9f ? 1f : Mathf.Lerp(Weight, 1f, 0.5f);
        }
        else
            Weight = Weight < 0.1f ? 0f : Mathf.Lerp(Weight, 0f, 0.5f);
    }

    public void EquipItem(Transform item)
    {
        this.Item = item;
        if (Item.TryGetComponent(out Rigidbody rb))
            rb.isKinematic = true;
        foreach (Collider c in Item.GetComponents<Collider>())
            c.enabled = false;

        Item.SetParent(visualParent);

        Item.localPosition = Vector3.zero;
        Item.localEulerAngles = new Vector3(0f, 0f, 180);
        Item.localScale = new Vector3(Mathf.Abs(Item.localScale.x),
                                   Mathf.Abs(Item.localScale.y),
                                   Mathf.Abs(Item.localScale.z));
    }

    public void UnequipItem()
    {
        if (Item)
        {
            if (Item.TryGetComponent(out Rigidbody rb))
                rb.isKinematic = false;

            foreach (Collider c in Item.GetComponents<Collider>())
                c.enabled = true;

            Item.SetParent(null);

            Item = null;
        }
    }

    private void Aim()
    {
        Vector3 mousePoint = _.MouseWorldPositionRaycast();
        movement.FlipSpriteScale(mousePoint.x - transform.position.x);
        target.position = mousePoint;
    }
}
