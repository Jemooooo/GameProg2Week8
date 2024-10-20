using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float bounceForce = 5f; // Force to apply when bouncing
    public int maxBounces = 1;     // Maximum number of bounces allowed
    private int bounceCount = 0;   // Count of current bounces

    private Rigidbody rb;          // Reference to the Rigidbody

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Get the Rigidbody component
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if the object hit has the tag "Enemy"
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Hit Enemy: " + collision.gameObject.name);

            // Apply damage to the enemy
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(1); // Apply damage
                Debug.Log("Enemy health: " + enemy.health);
            }

            bounceCount++;

            // Reflect the projectile's velocity if it hasn't reached max bounces
            if (bounceCount <= maxBounces)
            {
                if (rb != null)
                {
                    // Reflect the velocity using collision normal
                    Vector3 bounceDirection = Vector3.Reflect(rb.velocity.normalized, collision.contacts[0].normal);
                    rb.velocity = bounceDirection * bounceForce;
                    Debug.Log("Bouncing projectile to the next enemy.");
                }
            }
            else
            {
                // Destroy the projectile if max bounces are reached
                Debug.Log("Max bounces reached, destroying projectile.");
                Destroy(gameObject);
            }
        }
    }
}
