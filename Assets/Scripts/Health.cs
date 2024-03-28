using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float MaxHealth { get; private set; } = 100f;
    public float CurrentHealth { get; private set; }

    [SerializeField] public Image healthBar;
    [SerializeField] public Animator animator;

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
    }

    public void heal(float amount)
    {
        Debug.Log("healing");
        CurrentHealth += amount;
        if (CurrentHealth >= 100)
        {
            Debug.Log("Health is already at max");
        }
    }
    private void Die()
    {
        animator.SetTrigger("Death");
        // Add any death-related logic here
    }

    public void UpdateHealthBar()
    {
        // Check if healthBar is assigned before updating the health bar
        if (healthBar != null)
        {
            healthBar.fillAmount = Mathf.Clamp01(CurrentHealth / MaxHealth);
        }
        else
        {
            Debug.LogError("Health bar image is not assigned in the inspector.");
        }
    }

}
