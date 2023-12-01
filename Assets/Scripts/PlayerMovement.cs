using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEditor;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float standardspeed;
    [SerializeField]
    private float speed;
    private GameObject thisGameObject;

    [SerializeField]
    private float rotationSpeed;
    public int maxHealth = 100;
    public int currentHealth;
    PhotonView view;
    public SpriteRenderer spriteRenderer;
    public Sprite deadsprite;
    public float despawntimer = 2;

    private void Start()
    {
        standardspeed = speed;
        view = GetComponent<PhotonView>();
        thisGameObject = GetComponent<GameObject>();
        currentHealth = maxHealth;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        if(view.IsMine)
        {
            if (currentHealth < 0)
            {
                Die();

                despawntimer -= Time.deltaTime;
                if (despawntimer < 0)
                {
                    Remove();
                    //Debug.Log("Player has died.");
                }
            }
            else
            {
                float horizontalInput = Input.GetAxis("Horizontal");
                float verticalInput = Input.GetAxis("Vertical");

                Vector2 movementDirection = new Vector2(horizontalInput, verticalInput);
                float inputMagnitude = Mathf.Clamp01(movementDirection.magnitude);
                movementDirection.Normalize();

                transform.Translate(movementDirection * speed * inputMagnitude * Time.deltaTime, Space.World);

                if (movementDirection != Vector2.zero)
                {
                    Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, movementDirection);
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
                }
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.CompareTag("spraycan"))
        {
            
            speed *= 0.8f; 
            Debug.Log("Fry's speed reduced to: " + speed);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
      
        if (other.gameObject.CompareTag("spraycan"))
        {
            
            speed = standardspeed;
            Debug.Log("Fry's speed restored to: " + speed);
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
        //Remove();

    }

    void Remove()
    {
        Destroy(gameObject);
        Destroy(this);
    }

    /*
     *         float despawntimer = 2;
        despawntimer -= Time.deltaTime;
        if (despawntimer < 0)
        {
            Remove();
            Debug.Log("Player has died.");
        }
     */

}