using UnityEngine;

public class healer : MonoBehaviour
{
    public Health pHealth; // Reference to the player's health script

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && other.CompareTag("heal"))
        {
            // Ensure pHealth reference is not null before accessing it
            if (pHealth != null)
            {
                // Increase the player's health
                pHealth.health += 20;
                Debug.Log("Player's Health Increased: " + pHealth.health);
            }
            else
            {
                Debug.LogError("Player's health script reference is null.");
            }

            // Disable the heal object after the player collides with it
            gameObject.SetActive(false);
        }
    }
}
