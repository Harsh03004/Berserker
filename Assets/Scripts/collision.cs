using UnityEngine;

public class Collision : MonoBehaviour
{
    public Health pHealth;
    [SerializeField] Animator anim;
    [SerializeField] Animator Eanim;
    public AudioClip aclip,aclip2,aclip3;
    public AudioSource asource;
    [SerializeField] Transform playerDetectionPoint; // Point from which the enemy detects the player
    [SerializeField] float detectionRange = 10f; // Range within which the enemy detects the player
    public bool isGrounded;
    private void Start()
    {

        if (pHealth == null)
        {
            Debug.LogError("Player object does not have Health component.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        /*RaycastHit hit;
        if (Physics.Raycast(playerDetectionPoint.position, transform.forward, out hit, detectionRange))
        {

            if (other.CompareTag("Enemy"))
            {
                // Stop the movement of obstacles
                Debug.Log("Collided with an obstacle");
                asource.PlayOneShot(aclip3);

                *//*  anim.SetTrigger("Flinch");
                  Debug.Log("Playing Flinch animation");*//*
                asource.PlayOneShot(aclip);
                // Decrease player's health
                if (pHealth != null)
                {
                    Destroy(other.gameObject);
                    Debug.Log(pHealth.CurrentHealth);
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
                        else if (pHealth.CurrentHealth <= 0)
                        {
                            Debug.Log("Playing Death Sound");
                            asource.PlayOneShot(aclip2);
                            go.GetComponent<ObstacleMovement>().StopMovement();

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
        }*/
        if (other.CompareTag("hurdle"))
        {
            // Stop the movement of obstacles
            Debug.Log("Collided with an obstacle");

            anim.SetTrigger("Flinch");
            Debug.Log("Playing Flinch animation");
            // Decrease player's health
            if (pHealth != null)
            {
                pHealth.TakeDamage(10f);
                Debug.Log(pHealth.CurrentHealth);
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
                    else if (pHealth.CurrentHealth <= 0)
                    {
                        go.GetComponent<ObstacleMovement>().StopMovement();
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
    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("collision");
            isGrounded = true;
        }
    }
}