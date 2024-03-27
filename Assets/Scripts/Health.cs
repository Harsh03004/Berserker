using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float MaxHealth { get; private set; } = 100f;
    public float CurrentHealth { get; private set; }

    [SerializeField] private Image healthBar;
    [SerializeField] private Animator animator;

    private void Start()
    {
        CurrentHealth = MaxHealth;
        UpdateHealthBar();
    }

    public void TakeDamage(float amount)
    {
        CurrentHealth -= amount;
        UpdateHealthBar();
        if (CurrentHealth <= 0)
        {
            Die();
        }
        else
        {
            animator.SetTrigger("Flinch"); // Trigger flinch animation
        }
    }

    private void Die()
    {
        animator.SetTrigger("Death");
        // Add any death-related logic here
    }

    public void UpdateHealthBar()
    {
        healthBar.fillAmount = Mathf.Clamp01(CurrentHealth / MaxHealth);
    }
}
