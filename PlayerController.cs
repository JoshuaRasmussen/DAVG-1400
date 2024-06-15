using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f; // default move speed
    [SerializeField] private float slowedSpeed = 2.5f; // slowed move speed
    [SerializeField] private float fasterSpeed = 7.5f; // quicker move speed
    [SerializeField] private float rotationSpeed = 5f; // rotation speed
    [SerializeField] private float jumpForce = 5f; // default jump force
    [SerializeField] private float gravity = 9.81f; // gravity variable

    private CharacterController controller; // initializes the controller
    private Vector3 moveDirection; // initializes moveability of character
    private bool isJumping; // keeps track of if player is jumping or not
    private bool secondJump; // keeps track of if the player has the ability to have a second jump.
    private bool isCrouching; // keeps track of if the player is crouching
    private bool isSprinting; // keeps track of if the player is sprinting
    private float horizontal; // makes it possible to change horizontal movement speed
    private float vertical; // makes it possible to change vertical speed

    public Vector2 Rotate;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>(); // Connects the script to the controller
    }

    // Update is called once per frame
    void Update()
    {
        if (controller.isGrounded) // makes sure to get rid of second jump when on the ground
        {
            secondJump = false;
        }


        Rotate.x += Input.GetAxis("Mouse X") * rotationSpeed; // Allows the mouse to rotate player figure
        transform.localRotation = Quaternion.Euler(0,-Rotate.x,0);

        // make sure to set up the "Crouch" button in Edit -> Project Settings -> Input Manager
        if (Input.GetButtonDown("Crouch") && controller.isGrounded) // puts player in and out of crouching postion when "Crouch" button is pressed
        {
            isSprinting = false; // prevents player from going back to sprinting without pressing the "Sprint" button

            if (isCrouching == true) //puts player back to normal
            {
                isCrouching = false;
                transform.localScale = new Vector3 (1,2,1);
            }
            else // puts the player into a crouching position
            {
                isCrouching = true;
                transform.localScale = new Vector3 (1,1,1);
            }
        }
        // make sure to set up the "Sprint" button in Edit -> Project Settings -> Input Manager
        else if (Input.GetButtonDown("Sprint")) // puts the player in and out of crouching position
        {
            isCrouching = false; // makes it so you can go straight into a sprint from crouching

            if (isSprinting == true) // returns the player back to norma speed
            {
                isSprinting = false;
            }
            else // puts the player into a sprinting movement
            {
                isSprinting = true;
            }
        }
        else if (Input.GetButtonDown("Jump") && controller.isGrounded && isCrouching == false) // Checks if Character is both grounded and the jump button is being pressed
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
            transform.localScale = new Vector3 (1,2,1); // returns player back to normal size when sprinting
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
