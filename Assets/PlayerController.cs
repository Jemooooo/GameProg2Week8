using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject projectilePrefab; // Assign this in the Unity Inspector
    public Transform projectileSpawnPoint; // Assign the spawn point in the Unity Inspector
    public float moveSpeed = 5f; // Adjust as needed
    public float projectileSpeed = 10f; // Adjust the speed of the projectile

    void Update()
    {

        // Shooting projectile when spacebar is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShootProjectile(); // Call the ShootProjectile method
        }
    }

    // Method to shoot the projectile
    void ShootProjectile()
    {
        // Instantiate the projectile at the spawn point
        GameObject projectile = Instantiate(projectilePrefab, projectileSpawnPoint.position, projectileSpawnPoint.rotation);

        // Add forward velocity to the projectile
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        if (rb != null)
        {
            // Use the projectileSpawnPoint's forward direction to ensure the projectile goes straight from the spawn point
            rb.velocity = projectileSpawnPoint.forward * projectileSpeed;
        }

        // Destroy the projectile after 2 seconds to clean up
        Destroy(projectile, 2f);
    }

}
