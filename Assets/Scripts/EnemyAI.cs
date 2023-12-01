using UnityEngine;

public class FlySwatter : MonoBehaviour
{
    public GameObject player;
    public float swatterSpeed = 3f;
    public float attackRange = 8f;
    public int damageAmount = 10;
    public float attackDelay = 0f;
    public Sprite SwatterSprite;
    public Sprite SwattedSprite;
    public SpriteRenderer spriteRenderer;
    public Vector3 targetPoint;
    [SerializeField]
    float closestDistance = Mathf.Infinity;

    void Update()
    {
        SetTarget();
        if(attackDelay < 0)
        {
            MoveTowardsPlayer();
            if (closestDistance < 0.5)
            {
                ApplyDamageToPlayer();
            }
            else
                spriteRenderer.sprite = SwatterSprite;
                spriteRenderer.size = new Vector2(0.3f,0.3f);
        }
        else
            attackDelay -= Time.deltaTime;


    }

    void SetTarget()
    {
        GameObject[] allObjects = GameObject.FindGameObjectsWithTag("Player");

        GameObject closestObject = null;

        foreach (GameObject obj in allObjects)
        {
            float distance = Vector3.Distance(obj.transform.position, targetPoint);

            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestObject = obj;
                player = obj;
            }
            else
            {
                closestDistance = Mathf.Infinity;
            }
        }
    }

    void MoveTowardsPlayer()
    {
        Vector2 direction = (player.transform.position - transform.position).normalized;
        transform.up = direction;
        if (closestDistance > attackRange)
        {
            transform.Translate(Vector2.up * swatterSpeed * Time.deltaTime);
        }
        direction = (player.transform.position - transform.position).normalized;
        transform.up = direction;
        transform.Translate(Vector2.up * swatterSpeed * Time.deltaTime);
    }

    void ApplyDamageToPlayer()
    {
        attackDelay = 2;
        player.GetComponent<PlayerMovement>().TakeDamage(damageAmount);
        spriteRenderer.sprite = SwattedSprite;
        closestDistance = Mathf.Infinity;
        Debug.Log("Attacked the Player");
    }
}




/*
 

        float distanceToPlayer = Vector2.Distance(transform.position, player.position);
        if (distanceToPlayer <= detectionRadius)
        {
            playerDetected = true;

            Vector2 direction = (player.position - transform.position).normalized;
            transform.up = direction;

            if (!isAttacking)
            {
                if (distanceToPlayer > attackRange)
                {
                    transform.Translate(Vector2.up * swatterSpeed * Time.deltaTime);
                }
                else
                {
                    isAttacking = true;
                    attackTimer = attackDelay;
                }
            }
            else
            {
                if (attackTimer > 0f)
                {
                    attackTimer -= Time.deltaTime;
                }
                else
                {
                    ApplyDamageToPlayer(distanceToPlayer);
                    isAttacking = false;
                }
            }
        }
        else
        {
            playerDetected = false;
            isAttacking = false;

            Vector2 direction = (player.position - transform.position).normalized;
            transform.up = direction;
            transform.Translate(Vector2.up * swatterSpeed * Time.deltaTime);
        }

 */