using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        
        currentHealth -= damage;
        Debug.Log("Player health is " + currentHealth);
        if (currentHealth <= 0)
        {          
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Player has died.");
        gameObject.SetActive(false);
    }
}