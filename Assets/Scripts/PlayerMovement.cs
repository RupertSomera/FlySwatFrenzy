using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float standardspeed;
    [SerializeField]
    private float speed;

    [SerializeField]
    private float rotationSpeed;


    private void Start()
    {
        standardspeed = speed;
    }
    void Update()
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

        int Helt = GameObject.Find("Fry").GetComponent<PlayerController>().currentHealth;
        if (Helt <= 0)
            Destroy(this);
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


}