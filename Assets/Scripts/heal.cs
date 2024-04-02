using UnityEngine;

public class heal : MonoBehaviour
{
    public float healAmount = 20f;
    public Health Phealth; // Reference to the player's Health component
    public AudioClip aclip;
    public AudioSource asource;

    private void OnTriggerEnter(Collider other)
    {
        // Check if the player enters the trigger zone
        if (other.CompareTag("heal"))
        {
            Debug.Log("Healing");
            
            // Check if the Phealth reference is not null
            if (Phealth != null)
            {
                Debug.Log("Health Script has been Correctly assigned");

                // Check if the player's current health is less than maximum health
                if (Phealth.CurrentHealth < Phealth.MaxHealth)
                {
                    asource.PlayOneShot(aclip);
                    Debug.Log("Checking if part");
                    // Calculate the amount of health needed to reach the maximum
                    float remainingHealth = Phealth.MaxHealth - Phealth.CurrentHealth;

                    // Check if the healing amount exceeds the remaining health needed
                    float actualHealAmount = Mathf.Min(remainingHealth, healAmount);

                    // Heal the player and update health bar
                    Phealth.heal(actualHealAmount);
                    Debug.Log("Current Health after healing: " + Phealth.CurrentHealth);
                    Phealth.UpdateHealthBar();
                    Destroy(other.gameObject);
                }
                else
                {
                    Debug.Log("Health is already at maximum.");
                    asource.PlayOneShot(aclip);
                }
            }
            else
            {
                // Phealth reference is null, log an error
                Debug.LogError("Phealth variable is not assigned.");
            }
        }
    }
}