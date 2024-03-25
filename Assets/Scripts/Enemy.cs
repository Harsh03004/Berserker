using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Health playerHealth; // Reference to the player's health script
    public float damage;
    public GameObject[] enemies;
    [SerializeField] Animator animator;

    private void OnTriggerEnter(Collider other)
    {
        // Ensure that the collision is with the player
        if (other.CompareTag("Player"))
        {
            Debug.Log("Enemy OnTriggerEnter");

            // Reduce player health upon collision
            playerHealth.health -= damage;
            Debug.Log("Player Health: " + playerHealth.health);

            // If player's health drops to or below zero, trigger death animation and stop game elements
            if (playerHealth.health <= 0)
            {
                Debug.Log("Player defeated!");

                // Trigger death animation if animator is assigned
                if (animator != null)
                {
                    animator.SetTrigger("Death");
                }

                // Stop enemy movement
                enemies = GameObject.FindGameObjectsWithTag("Enemy");
                foreach (GameObject enemy in enemies)
                {
                    ObstacleMovement movement = enemy.GetComponent<ObstacleMovement>();
                    if (movement != null)
                    {
                        movement.StopMovement();
                    }
                    else
                    {
                        Debug.LogWarning("ObstacleMovement component not found on enemy: " + enemy.name);
                    }
                }

                // Stop scoring and spawning if components are available
                Scoreing_system scoringSystem = FindObjectOfType<Scoreing_system>();
                if (scoringSystem != null)
                {
                    scoringSystem.stopcount();
                }
                else
                {
                    Debug.LogWarning("Scoring system component not found.");
                }

                SpawnManager spawnManager = FindObjectOfType<SpawnManager>();
                if (spawnManager != null)
                {
                    spawnManager.stopspawn();
                }
                else
                {
                    Debug.LogWarning("SpawnManager component not found.");
                }
            }
            else
            {
                Debug.Log("Player health decreased to: " + playerHealth.health);
            }
        }
    }
}
