using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slash : MonoBehaviour
{
    public Health pHealth;
    [SerializeField] Animator anim;

    public AudioSource asource;
    [SerializeField] Transform playerDetectionPoint; // Point from which the enemy detects the player
    [SerializeField] float detectionRange = 10f; // Range within which the enemy detects the player
    public bool hasattacked=false;
    // Start is called before the first frame update

  
   
    public void Update()
    {
        // Disable the attached "slash" script
        GetComponent<slash>().enabled = false;
        // Disable the BoxCollider component
        GetComponent<BoxCollider>().enabled = false;


        if (Input.GetMouseButtonDown(0))
        {
            // Disable the attached "slash" script
            GetComponent<slash>().enabled = true;
            // Disable the BoxCollider component
            GetComponent<BoxCollider>().enabled = true;


            hasattacked = true;
           anim.SetTrigger("Attack");
            
                

        }
    }
    private void OnTriggerEnter(Collider other)
    {


            if (other.CompareTag("Enemy") && hasattacked)
            {
                Debug.Log("Player has attacked");
/*                anim.SetTrigger("Attack");*/
                Destroy(other.gameObject);
            }
        Invoke("stop", 1.2f);
        }
     private void stop()
    {
        hasattacked=false;
    }  
}
