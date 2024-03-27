
using UnityEngine;
using UnityEngine.UI;

public class heal : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public Image healthBar;
    public float maxHealthValue = 100;
    public float healAmount = 20;
    public Health Phealth;
    // Start is called before the first frame update
   

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
       
        if (other.CompareTag("heal"))
        {
            Debug.Log("Healing");
            if (health < maxHealth)
            {
                health = Mathf.Min(health + healAmount, maxHealth);
                Debug.Log("Health increased to: " + health);
                Destroy(other.gameObject);
                Phealth.UpdateHealthBar();
            }
            else
            {
                Debug.Log("Health is already at maximum.");
                Destroy(other.gameObject);
            }
        }
    }
}
