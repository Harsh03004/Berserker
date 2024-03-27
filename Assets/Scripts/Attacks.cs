using UnityEngine;
using UnityEngine.UI;

public class Attacks : MonoBehaviour
{
    [SerializeField] Animator anim;
    public Button button;
    public bool isAttacking = false;
    public LayerMask enemy_layers;
    public Transform Attack_point;
    public float attack_range = 0.5f;

    private void Start()
    {
        //button.onClick.AddListener(ButtonPressed);
        Debug.Log("Attack start");
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            attack();
        }
    }

    public void attack()
    {
        Debug.Log("Attack the enemy");
        //attack animation
        anim.SetTrigger("Attack");

        //attack the enemy
        Collider[] hit_enemy = Physics.OverlapSphere(Attack_point.position, attack_range, enemy_layers);
        
    }

    private void OnDrawGizmosSelected()
    {
        if (Attack_point == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(Attack_point.position, attack_range);
    }
}
