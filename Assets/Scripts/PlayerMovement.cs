using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed;

    [SerializeField]
    private float rotationSpeed;

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
    private void OnTriggerEnter(Collider other)
    {
        // Check if the trigger is the "spraycan" GameObject
        if (other.gameObject.CompareTag("spraycan"))
        {
            // Reduce Fry's speed by 5
            speed -= 5f;
            Debug.Log("Fry's speed reduced to: " + speed);
        }
    }
}