using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 8; // Number of hits the enemy can take

    // Function to apply damage to the enemy
    public void TakeDamage(int damage)
    {
        // Reduce health by the amount of damage taken
        health -= damage;

        // Check if health is zero or less
        if (health <= 0)
        {
            Die();
        }
    }

    // Function to handle the enemy's death
    void Die()
    {
        // Destroy the enemy GameObject
        Debug.Log("Enemy destroyed!");
        Destroy(gameObject);
    }

    // Detect collision with projectile
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            if (gameObject.CompareTag("AbsorbEnemy"))
            {
                // The second enemy absorbs the projectile and takes damage
                Debug.Log("Projectile absorbed by " + gameObject.name);
                Destroy(collision.gameObject); // Absorb the projectile by destroying it
            }

            // Both enemies take damage regardless of absorption
            TakeDamage(1);
        }
    }
}
