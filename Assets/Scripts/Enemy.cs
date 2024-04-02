using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] Transform playerDetectionPoint; // Point from which the enemy detects the player
    [SerializeField] float detectionRange = 10f; // Range within which the enemy detects the player
    public AudioSource asource;
    public AudioClip aclip;
/*    public Health phealth;
*/
    private bool playerDetected = false;

    private void Update()
    {
        // Perform raycast to detect the player
        RaycastHit hit;
        if (Physics.Raycast(playerDetectionPoint.position, transform.forward, out hit, detectionRange))
        {
         
            if (hit.collider.CompareTag("Player"))
            {
                
                playerDetected = true;
                /*if(phealth.CurrentHealth > 0)
                {
                    phealth.TakeDamage(20f);
                }   
                else if(phealth.CurrentHealth <=0){
                    animator.SetTrigger("Death");
                }*/

            }
        }
        else
        {
            // Player not detected
            playerDetected = false;
        }

        // Update animator parameter based on player detection
        animator.SetBool("Attack", playerDetected);

    }
}

/*   private void die()
   {
       // Check if animator is null to prevent NullReferenceException
       if (animator == null)
       {
           Debug.LogError("Animator is null in die() method.");
           return;
       }

       //dying animation
       animator.SetTrigger("DIE");

       Debug.Log("ENEMY IS DEAD");
       //disabling the collider
       GetComponent<Collider>().enabled = false;

       //diabling the script
       this.enabled = false;
   }*/
