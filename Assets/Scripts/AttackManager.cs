using UnityEngine;
using System;

public class AttackManager : MonoBehaviour
{
    public static AttackManager Instance { get; private set; }
    [SerializeField] Animator Panim;
    [SerializeField] Animator Eanim;

    // Public fields for GameObjects
    public GameObject playerGameObject;
    public GameObject enemyGameObject;

    // Events for player and enemy attacks
    public event Action<GameObject> OnPlayerAttack;
    public event Action<GameObject> OnEnemyAttack;

    public float playerAttackTime;
    public float enemyAttackTime;

    private void Start()
    {
        Debug.Log("accesssssss");
        Awake();
    }
    private void Awake()
    {
        // Ensure only one instance of AttackManager exists
        if (Instance == null)
        {
            Debug.Log("Awake has been read");
            Instance = this;
        }
        else
        {
            Debug.LogWarning("Another instance of AttackManager already exists. Destroying this one.");
            Destroy(gameObject);
        }
    }

    public void PlayerAttacked(GameObject player)
    {
        if (OnPlayerAttack != null)
        {
            OnPlayerAttack(player);
            playerAttackTime = Time.time; // Record the time of the player's attack
            Debug.Log("Player Attack time=" + AttackManager.Instance.playerAttackTime);
            DetermineAttackOrder(); // Check the attack order
        }
    }

    public void EnemyAttacked(GameObject enemy)
    {
        if (OnEnemyAttack != null)
        {
            OnEnemyAttack(enemy);
            enemyAttackTime = Time.time; // Record the time of the enemy's attack
            DetermineAttackOrder(); // Check the attack order
        }
    }

    private void DetermineAttackOrder()
    {
        if (playerAttackTime < enemyAttackTime)
        {
            Debug.Log("Player Attacked First");
            Eanim.SetTrigger("DIE");
        }
        else if (playerAttackTime > enemyAttackTime)
        {
            Debug.Log("Enemy Attacked First");
            Panim.SetTrigger("Death");
            Destroy(playerGameObject);
        }
        else
        {
            Debug.Log("Both Attacked Simultaneously");
        }
    }
}
