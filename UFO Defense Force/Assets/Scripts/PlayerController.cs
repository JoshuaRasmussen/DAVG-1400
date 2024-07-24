using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float speed;
    public float xRange;
    public Transform blaster;
    public GameObject Projectile;
    private Rigidbody playerRB;
    private int Pickups = 0;

    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Set HorizontalInput to recieve values from keyboard
        horizontalInput = Input.GetAxis("Horizontal");

        // Moves player left and right
        transform.Translate(Vector3.right * speed * horizontalInput * Time.deltaTime);

        // Keeps player within bounds
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }

        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        // if spacebar is pressed, sends out projectile
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Create Projectile at the blaster transform position maintaining the objects rotation.
            Instantiate(Projectile, blaster.transform.position, Projectile.transform.rotation);
        }

        
    }
    
    // deletes objects with trigger that hits the player
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Pickup"))
        {
            Destroy(other.gameObject);
            Pickups++;
            Debug.Log("player has " + Pickups + " pickup(s) in inventory!");
        }
        
    }
}
