using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f; // default move speed
    [SerializeField] private float slowedSpeed = 2.5f;
    [SerializeField] private float fasterSpeed = 7.5f;
    [SerializeField] private float jumpForce = 5f; // default jump force
    [SerializeField] private float gravity = 9.81f; // gravity variable

    private CharacterController controller; // initializes the controller
    private Vector3 moveDirection; // initializes moveability of character
    private bool isJumping; // keeps track of if player is jumping or not
    private bool secondJump; // keeps track of if the player has the ability to have a second jump.
    private bool isCrouching;
    private bool jumping;
    private bool isSprinting;
    private float horizontal;
    private float vertical;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>(); // Connects the script to the controller
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Crouch") && controller.isGrounded)
        {
            if (isCrouching == true && jumping == false)
            {
                isCrouching = false;
                jumping = true;
            }
            else
            {
                isCrouching = true;
                jumping = false;
            }
        }
        else if (Input.GetButtonDown("Sprint"))
        {
            isCrouching = false;
            jumping = true;
            if (isSprinting == true)
            {
                isSprinting = false;
            }
            else
            {
                isSprinting = true;
            }
        }
        else if (Input.GetButtonDown("Jump") && controller.isGrounded && jumping == true) // Checks if Character is both grounded and the jump button is being pressed
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

        if (isCrouching == true) // Slow speed
        {
            horizontal = Input.GetAxis("Horizontal") * slowedSpeed;
            vertical = Input.GetAxis("Vertical") * slowedSpeed;
        }
        else if (isSprinting == true) // Fast speed
        {
            horizontal = Input.GetAxis("Horizontal") * fasterSpeed;
            vertical = Input.GetAxis("Vertical") * fasterSpeed;
        }
        else if (isCrouching == false && isSprinting == false) // Normal speed
        {
            horizontal = Input.GetAxis("Horizontal") * moveSpeed; 
            vertical = Input.GetAxis("Vertical") * moveSpeed; 
        }

        moveDirection.y -= (gravity * Time.deltaTime); // makes the player fall after jumping
        
        Vector3 movement = new Vector3(horizontal, moveDirection.y, vertical); // allows player movement

        movement = transform.TransformDirection(movement); // transforms the movement vectors
        
        controller.Move(movement * Time.deltaTime); // calculates the characters movement for each direction made

        if (isJumping == true ) // makes isJumping become false again
        {
            isJumping = false;
        }
    }
}
