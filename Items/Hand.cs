using Lodash;
using UnityEngine;
using UnityEngine.U2D.IK;

[RequireComponent(typeof(Movement))]
public class Hand : MonoBehaviour
{
    //private Transform hand;
    [SerializeField]
    private LimbSolver2D solver2D;
    [SerializeField]
    private Transform target;

    private float Weight
    {
        get => solver2D.weight;
        set { solver2D.weight = value; }
    }
    private Movement movement;

    void Start() => movement = GetComponent<Movement>();

    void Update()
    {
        bool isAiming = _.IsMouseRightPressed();
        movement.isFocused = isAiming;

        if (isAiming)
        {
            Aim();
            Weight = Weight > 0.9f ? 1f : Mathf.Lerp(Weight, 1f, 0.5f);
        }
        else Weight = Weight < 0.1f ? 0f : Mathf.Lerp(Weight, 0f, 0.5f);
    }

    private void Aim()
    {
        Vector3 mousePoint = _.MouseWorldPositionRaycast();
        movement.FlipSpriteScale(mousePoint.x - transform.position.x);
        target.position = mousePoint;
    }

    //public void EquipItem(Transform item)
    //{
    //    if (item.TryGetComponent(out Rigidbody rb)) rb.isKinematic = true;
    //    foreach (Collider collider in item.GetComponents<Collider>())
    //        collider.enabled = false;
    //    item.SetParent(hand);
    //    item.localPosition = Vector3.zero;
    //    item.localEulerAngles = new Vector3(0f, 0f, 180);
    //    item.localScale = new Vector3(Mathf.Abs(item.localScale.x),
    //                                Mathf.Abs(item.localScale.y),
    //                                Mathf.Abs(item.localScale.z));
    //}
}
