using UnityEngine;
using UnityEngine.UI;

public class Attacks : MonoBehaviour
{
    [SerializeField] Animator anim;
    public Button button;
    public bool isAttacking = false;
    public GameObject enemyPrefab; // Prefab of the enemy

    private void Start()
    {
        //button.onClick.AddListener(ButtonPressed);
        Debug.Log("Attack start");
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            attack();
        }
    }
    public void attack()
    {
        if (!isAttacking && anim != null && enemyPrefab != null)
        {
            anim.SetBool("Attack", true);
            isAttacking = true; // Set isAttacking to true to prevent multiple attacks before animation completes
            anim.SetBool("attack", true);
            // Instantiate the enemyPrefab and store the instance
            GameObject instantiatedEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            if (instantiatedEnemy != null)
            {
                Debug.Log("Enemy prefab instantiated");
                // You may want to handle the instantiatedEnemy reference for further logic

                // Delay destroying the enemy to allow for attack animation
                Destroy(instantiatedEnemy, 0.5f); // Adjust the delay as needed
            }
            else
            {
                Debug.Log("Failed to instantiate enemy prefab");
            }

            Invoke("ResetAttack", 0.1f);
        }
    }

    // This method can be called when the attack animation is completed
    public void ResetAttack()
    {
        if (anim != null)
        {
            anim.SetBool("Attack", false);
            anim.SetBool("attack", false);
            isAttacking = false; // Reset isAttacking to allow for the next attack
        }
    }
}
