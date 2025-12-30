using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    Animator animator;
    Vector2 movement;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // Normalize to avoid faster diagonals
        movement = movement.normalized;

        // Move using transform
        transform.position += (Vector3)(movement * moveSpeed * Time.deltaTime);

        // Animation
        bool isMoving = movement != Vector2.zero;
        animator.SetBool("IsMoving", isMoving);

        if (isMoving)
        {
            animator.SetFloat("MoveX", movement.x);
            animator.SetFloat("MoveY", movement.y);
        }
    }
}
