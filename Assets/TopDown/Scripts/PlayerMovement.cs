using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    Rigidbody2D rb;
    Animator animator;
    Vector2 movement;

    // Store last non-zero direction
    Vector2 lastDirection = Vector2.down;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Raw input
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        movement = new Vector2(x, y).normalized;

        bool isMoving = movement != Vector2.zero;
        animator.SetBool("IsMoving", isMoving);

        if (isMoving)
        {
            // Choose dominant axis
            if (Mathf.Abs(x) > Mathf.Abs(y))
            {
                lastDirection = new Vector2(Mathf.Sign(x), 0);
            }
            else
            {
                lastDirection = new Vector2(0, Mathf.Sign(y));
            }

            animator.SetFloat("MoveX", lastDirection.x);
            animator.SetFloat("MoveY", lastDirection.y);
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
