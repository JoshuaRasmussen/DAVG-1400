using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private float gravity = 9.81f;

    private CharacterController controller;
    private Vector3 moveDirection;
    private bool isJumping;
    private bool secondJump;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal") * moveSpeed;
        float vertical = Input.GetAxis("Vertical") * moveSpeed;
        
        if (Input.GetButtonDown("Jump") && controller.isGrounded)
        {
            isJumping = true;
            secondJump = true;
            moveDirection.y = jumpForce;
        }
        else if (Input.GetButtonDown("Jump") && secondJump == true)
        {
            secondJump = false;
            moveDirection.y = jumpForce;
        }
        moveDirection.y -= (gravity * Time.deltaTime);
        Vector3 movement = new Vector3(horizontal, moveDirection.y, vertical);
        movement = transform.TransformDirection(movement);
        controller.Move(movement * Time.deltaTime);

        if (isJumping == true)
        {
            isJumping = false;
        }
    }
}
