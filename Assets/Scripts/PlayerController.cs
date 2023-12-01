using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public SpriteRenderer spriteRenderer;
    public Sprite deadsprite;
    public bool isAlive = true;
    

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        currentHealth = maxHealth;
    }

    void Update()
    {
        if (currentHealth < 0)
        {
            isAlive = false;
            Die();
        }
    }

    public void TakeDamage(int damage)
    {
        
        currentHealth -= damage;
        Debug.Log("Player health is " + currentHealth);
        
    }

    void Die()
    {
        spriteRenderer.sprite = deadsprite;
        transform.localScale = new Vector2(0.1f, 0.1f);
        Debug.Log("Player has died.");
        float despawntimer = 2;
        despawntimer -= Time.deltaTime;
        if (despawntimer < 0)
        {
            Destroy(gameObject);
        }
    }
}