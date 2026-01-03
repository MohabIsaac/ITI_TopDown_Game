using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [Header("Bullet Settings")]
    public GameObject bulletPrefab;    // Your projectile prefab (facing right)
    public Transform shootPoint;       // Where bullets spawn
    public float bulletSpeed = 10f;

    [Header("Player Direction")]
    public Vector2 lastDirection = Vector2.right; // Default facing right

    void Update()
    {
        // Example input for changing lastDirection
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        if (h != 0) lastDirection = new Vector2(h, 0);
        else if (v != 0) lastDirection = new Vector2(0, v);

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0)) // Press Space or Mouse0 to shoot
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Spawn bullet
        GameObject bullet = Instantiate(bulletPrefab, shootPoint.position, Quaternion.identity);

        // Get direction and normalize
        Vector2 dir = lastDirection.normalized;

        // Rotate bullet to face direction
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        bullet.transform.rotation = Quaternion.Euler(0, 0, angle);

        // Set velocity if using Rigidbody2D
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = dir * bulletSpeed;
        }

        // Optional: flip sprite for left direction (if needed)
        SpriteRenderer sr = bullet.GetComponent<SpriteRenderer>();
        if (sr != null)
        {
            sr.flipX = dir.x < 0; // Flip only horizontally when shooting left
        }
    }
}
