using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] Transform playerDetectionPoint; // Point from which the enemy detects the player
    [SerializeField] float detectionRange = 10f; // Range within which the enemy detects the player

    private bool playerDetected = false;

    private void Update()
    {
        // Perform raycast to detect the player
        RaycastHit hit;
        if (Physics.Raycast(playerDetectionPoint.position, transform.forward, out hit, detectionRange))
        {
            if (hit.collider.CompareTag("Player"))
            {
                // Player detected within detection range
                playerDetected = true;
                AttackManager.Instance.EnemyAttacked(gameObject);
                Debug.Log("Enemy Attack time="+ AttackManager.Instance.enemyAttackTime);
                /*GameObject[] ground = GameObject.FindGameObjectsWithTag("Obstacle");
                foreach (GameObject go in ground)
                {x  
                    go.GetComponent<ObstacleMovement>().StopMovement();
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
    