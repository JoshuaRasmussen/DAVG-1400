using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 10.0f;
    private Rigidbody playerRb;
    public bool isOnGround = true;
    private float jumpForce = 5.0f;
    private float zBound = 10;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        ConstrainPlayerPosition();
    }

    // Moves the player based on arrow key input and space bar
    void MovePlayer()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        playerRb.AddForce(Vector3.forward * speed * vertical);
        playerRb.AddForce(Vector3.right * speed * horizontal);
        
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }
    }

    // prevents player from going off the top of the screen
    void ConstrainPlayerPosition()
    {
        if (transform.position.z > zBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zBound);
        }
    }

    // controls player interactivity amongst game objects and environment
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            isOnGround = true;
        }
    }
}
