using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    private const float MAX_ZOOM = 5f;
    private const float MIN_ZOOM = 2f;
    private const float SMOOTH_SPEED = 0.125f;

    [SerializeField]
    private Transform target;
    [SerializeField]
    private Vector3 offset = new Vector3(0, 5f, 0.42f);

    void FixedUpdate()
    {
        offset.y = Mathf.Clamp(offset.y - Input.mouseScrollDelta.y / 5, MIN_ZOOM, MAX_ZOOM);
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, SMOOTH_SPEED);
        transform.position = smoothedPosition;
    }
}
