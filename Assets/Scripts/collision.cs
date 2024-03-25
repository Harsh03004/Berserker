
using UnityEngine;


public class collision : MonoBehaviour
{
    public GameObject player;
    public GameObject charmodel;
    public GameObject[] obstacles;
    public Health pHealth;
    public int damage;
    [SerializeField] Animator anim;
    
    private void OnTriggerEnter(Collider other)
    {
        // Check if the collider belongs to an obstacle with the "hurdle" tag
        if (other.CompareTag("hurdle"))
        {
            Debug.Log("Collision has occured");
            // Check if the obstacle has the ObstacleMovement component
            obstacles = GameObject.FindGameObjectsWithTag("Obstacle");

            // Check if the Scoreing_system component exists on the Scoreing_system GameObject
            Scoreing_system scs = FindObjectOfType<Scoreing_system>();
          

            SpawnManager sw = FindObjectOfType<SpawnManager>();
            if (obstacles.Length != 0)
            {
                // Stop the movement of the obstacle
                pHealth.health -= damage;
                if(pHealth.health <= 0)
                {
                    anim.SetTrigger("Death");
                    Debug.Log("Stop ground movement");
                    foreach (GameObject go in obstacles)
                    {
                        go.GetComponent<ObstacleMovement>().StopMovement();
                    }
                    sw.stopspawn();

                    // Check if the Scoreing_system component was found
                    if (scs != null)
                    {
                        Debug.Log("Counting Stop");
                        scs.stopcount();
                    }
                    else
                    {
                        Debug.LogWarning("Scoreing_system component not found.");
                    }
                }
                
            }
            else
            {
                Debug.LogError("ObstacleMovement component not found on the collided object.");
            }
        }
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("Collision has occured");
            // Check if the obstacle has the ObstacleMovement component
            obstacles = GameObject.FindGameObjectsWithTag("Obstacle");

            // Check if the Scoreing_system component exists on the Scoreing_system GameObject
            Scoreing_system scs = FindObjectOfType<Scoreing_system>();


            SpawnManager sw = FindObjectOfType<SpawnManager>();
            if (obstacles.Length != 0)
            {
                // Stop the movement of the obstacle
                pHealth.health -= damage;
                if (pHealth.health <= 0)
                {
                    anim.SetTrigger("Death");
                    Debug.Log("Stop ground movement");
                    foreach (GameObject go in obstacles)
                    {
                        go.GetComponent<ObstacleMovement>().StopMovement();
                    }
                    sw.stopspawn();

                    // Check if the Scoreing_system component was found
                    if (scs != null)
                    {
                        Debug.Log("Counting Stop");
                        scs.stopcount();
                    }
                    else
                    {
                        Debug.LogWarning("Scoreing_system component not found.");
                    }
                }

            }
            else
            {
                Debug.LogError("ObstacleMovement component not found on the collided object.");
            }
        }
    }
}
