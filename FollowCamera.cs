using Lodash;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    private const float MAX_ZOOM = 4f;
    private const float MIN_ZOOM = 2f;
    private const float SMOOTH_SPEED = 0.125f;
    private Vector3 intialOffset;

    [SerializeField]
    private Transform target;
    [SerializeField]
    private Vector3 offset = new Vector3(0, MAX_ZOOM, 0.42f);

    private void Start() => this.intialOffset = offset;

    void FixedUpdate()
    {
        offset.y = Mathf.Clamp(offset.y - _.MouseScrollDelta.y / 5, MIN_ZOOM, MAX_ZOOM);

        if (_.IsMouseMiddlePressed())
            offset = intialOffset;

        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, SMOOTH_SPEED);
        transform.position = smoothedPosition;
    }
}
