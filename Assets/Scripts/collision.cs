using UnityEngine;

public class Collision : MonoBehaviour
{
    public  Health pHealth;

    private void Start()
    {
     
        if (pHealth == null)
        {
            Debug.LogError("Player object does not have Health component.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("hurdle"))
        {
            // Stop the movement of obstacles
            Debug.Log("Collided with an obstacle");

            // Decrease player's health
            if (pHealth != null)
            {
                pHealth.TakeDamage(20f);
            }
            else
            {
                Debug.LogError("Player's health script reference is null.");
            }

            // Stop obstacle movement and count score accordingly

            GameObject[] Ground = GameObject.FindGameObjectsWithTag("Obstacle");
            foreach (GameObject go in Ground)
            {
                if (Ground != null)
                {
                    if (pHealth.CurrentHealth > 0)
                    {
                        go.GetComponent<ObstacleMovement>().Move();
                    }
                    else if(pHealth.CurrentHealth <=0)
                    {
                        go.GetComponent <ObstacleMovement>().StopMovement();
                    }
                }
                else
                {
                    Debug.LogWarning("ObstacleMovement component not found on the obstacle GameObject.");
                }
            }

            Scoreing_system scs = FindObjectOfType<Scoreing_system>();
            if (scs != null)
            {
                if (pHealth.CurrentHealth <= 0)
                {
                    scs.stopcount();
                }
                else
                {
                    scs.countscore();
                }
            }
            else
            {
                Debug.LogWarning("Scoreing_system component not found.");
            }
        }
    }
    
}
