using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public Image healthBar;
    public float maxHealthValue = 100;
    public float healAmount = 20;
    [SerializeField]Animator animator;
    public float damage;
    public GameObject[] enemies;

    void Start()
    {
        maxHealth = maxHealthValue;
        UpdateHealthBar();
    }

    void Update()
    {
        UpdateHealthBar();
        
    }

    public void UpdateHealthBar()
    {
        healthBar.fillAmount = Mathf.Clamp(health / maxHealth, 0, 1);
    }
    private void OnTriggerEnter(Collider other)
    { 
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("Enemy OnTriggerEnter");

            // Reduce player health upon collision
            health -= damage;
            Debug.Log("Player Health: " + health);

            // If player's health drops to or below zero, trigger death animation and stop game elements
            if (health <= 0)
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
                Debug.Log("Player health decreased to: " + health);
            }
        }


    }
}
