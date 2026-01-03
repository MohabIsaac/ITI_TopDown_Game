using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 5;
    public int currentHealth;

    void Awake()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die();
        }
    }

    public void SetHealthToZero()
    {
        currentHealth = 0;
        Die();
    }

    void Die()
    {
        Debug.Log("Player died");

        // Optional:
        // disable movement, play animation, reload scene, etc.
        // GetComponent<PlayerMovement>().enabled = false;
        // animator.SetTrigger("Die");
    }
}
