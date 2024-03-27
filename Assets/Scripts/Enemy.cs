using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] Animator animator;
    private Health pHealth;

    private void Start()
    {
        animator = GetComponent<Animator>();
        if (animator == null)
        {
            Debug.LogError("Animator component not found on the enemy GameObject.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Start attack animation when colliding with the player
            if (animator != null)
            {
                animator.SetBool("Attack", true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Stop attack animation when the player exits the collider
            if (animator != null)
            {
                animator.SetBool("Attack", false);
            }
        }
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
    