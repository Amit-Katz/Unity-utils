using Lodash;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour
{
    private const float DEFAULT_SPEED = 3f;

    public float speed = DEFAULT_SPEED;
    public bool isFocused = false;

    [SerializeField]
    private Transform sprite;
    [SerializeField]
    private Animator animator;

    private Rigidbody rb;

    private void Start() => rb = GetComponent<Rigidbody>();

    private void Update()
    {
        Vector2 inputVector = GetInputVector();
        rb.velocity = new Vector3(inputVector.x, rb.velocity.y, inputVector.y);

        animator.speed = speed / DEFAULT_SPEED;
        animator.SetBool("isWalking", inputVector != Vector2.zero);

        if (!isFocused) FlipSpriteScale(inputVector.x);
    }

    public void FlipSpriteScale(float relative)
    {
        if (relative / sprite.localScale.x > 0)
            sprite.localScale = new Vector3(
                sprite.localScale.x * -1,
                sprite.localScale.y,
                sprite.localScale.z);
    }

    private Vector2 GetInputVector()
    {
        float x = _.InputX(), y = _.InputY();
        Vector2 inputVector = new Vector2(x, y) * speed;

        if (_.InputXRaw() != 0f &&
            _.InputYRaw() != 0f)
            inputVector /= Mathf.Sqrt(x * x + y * y);

        return inputVector;
    }
}
