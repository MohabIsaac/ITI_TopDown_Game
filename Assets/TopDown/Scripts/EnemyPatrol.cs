using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public Animator animator;
    public Transform pointA;
    public Transform pointB;
    public float speed = 2f;

    private Vector3 target;

    void Start()
    {
        target = pointB.position; // Start moving towards pointB
    }

    void Update()
    {
        // Move towards target
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        // If reached the target, switch
        if (Vector3.Distance(transform.position, target) < 0.1f)
        {
            target = target == pointA.position ? pointB.position : pointA.position;
        }

        Vector2 movement = target - transform.position;
        UpdateAnimation(movement);

    }

    public void UpdateAnimation(Vector2 movement)
    {
        bool isMoving = movement.magnitude > 0;

        animator.SetBool("isMoving", isMoving);
        animator.SetFloat("Xaxis", movement.x);
        animator.SetFloat("Yaxis", movement.y);

        if (isMoving)
        {
            // Decide direction based on dominant axis
            // if (Mathf.Abs(movement.x) > Mathf.Abs(movement.y))
            // {
            //     // Horizontal movement dominates
            //     if (movement.x > 0) animator.Play("WalkRight");
            //     else animator.Play("WalkLeft");
            // }
            // else
            // {
            //     // Vertical movement dominates
            //     if (movement.y > 0) animator.Play("WalkUp");
            //     else animator.Play("WalkDown");
            // }
        }
        else
        {
            // Idle animation based on last direction
            float lastX = animator.GetFloat("Xaxis");
            float lastY = animator.GetFloat("Yaxis");

            // if (Mathf.Abs(lastX) > Mathf.Abs(lastY))
            // {
            //     // if (lastX > 0) animator.Play("IdleRight");
            //     // else animator.Play("IdleLeft");
            // }
            // else
            // {
            //     // if (lastY > 0) animator.Play("IdleUp");
            //     // else animator.Play("IdleDown");
            // }
        }
}
}
