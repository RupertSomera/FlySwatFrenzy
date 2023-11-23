using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public SpriteRenderer spriteRenderer;
    public Sprite deadsprite;

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
        //gameObject.SetActive(false);
        spriteRenderer.sprite = deadsprite; gameObject.transform.localScale = new Vector2(0.1f,0.1f);
    }
}