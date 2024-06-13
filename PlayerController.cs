using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f; // default move speed
    [SerializeField] private float jumpForce = 5f; // default jump force
    [SerializeField] private float gravity = 9.81f; // gravity variable

    private CharacterController controller; // initializes the controller
    private Vector3 moveDirection; // initializes moveability of character
    private bool isJumping; // keeps track of if player is jumping or not
    private bool secondJump; // keeps track of if the player has the ability to have a second jump.

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>(); // Connects the script to the controller
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal") * moveSpeed; // Keeps Track of Horizontal Movement
        float vertical = Input.GetAxis("Vertical") * moveSpeed; // Keeps Track of Vertical Movement
        
        if (Input.GetButtonDown("Jump") && controller.isGrounded) // Checks if Character is both grounded and the jump button is being pressed
        {
            isJumping = true;
            secondJump = true; // allows the character to have a second jump
            moveDirection.y = jumpForce; 
        }
        else if (Input.GetButtonDown("Jump") && secondJump == true) // allows another jump when both the jump button is pressed and secondJump equals true
        {
            secondJump = false;
            moveDirection.y = jumpForce;
        }

        moveDirection.y -= (gravity * Time.deltaTime); // makes the player fall after jumping

        Vector3 movement = new Vector3(horizontal, moveDirection.y, vertical); // allows player movement

        movement = transform.TransformDirection(movement); // transforms the movement vectors

        controller.Move(movement * Time.deltaTime); // calculates the characters movement for each direction made

        if (isJumping == true) // makes isJumping become false again
        {
            isJumping = false;
        }
    }
}
