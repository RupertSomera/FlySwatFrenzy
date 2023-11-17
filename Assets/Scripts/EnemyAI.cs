using UnityEngine;

public class FlySwatter : MonoBehaviour
{
    public Transform player;
    public float detectionRadius = 5f;
    public float swatterSpeed = 3f;
    public float attackRange = 1f;
    public int damageAmount = 10;
    public float attackDelay = 2f;
    private bool playerDetected = false;
    private bool isAttacking = false;
    private float attackTimer = 0f;

    void Update()
    {
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
    }

    void ApplyDamageToPlayer(float distanceToPlayer)
    {
        if (distanceToPlayer <= attackRange)
        {
            player.GetComponent<PlayerController>().TakeDamage(damageAmount);
            Debug.Log("Attacked the Player");
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}