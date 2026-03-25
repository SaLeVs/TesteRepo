using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform orientation;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Animator animator;
    

    [Header("Movement settings")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;
    

    private float horizontalInput;
    private float verticalInput;
    private Vector3 movementDirection;


    void Update()
    {
        MyInput();

        if(Input.GetKeyDown(KeyCode.Space) && IsPlayerOnGround())
        {
            Jump();
        }

        PlayerAnimation();
    }

    
    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
    }

    private void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    private void PlayerAnimation()
    {
        if(IsPlayerOnGround())
        {
            if(movementDirection.magnitude > 0.1f)
            {
                animator.SetInteger("State", 1);
            }
            else
            {
                animator.SetInteger("State", 0);
            }

            if(Input.GetKeyDown(KeyCode.Space))
            {
                animator.SetInteger("State", 2);
            }
           
        }
        else
        {
            animator.SetInteger("State", 3);
        }
        Debug.Log("Estado Jog: " + animator.GetInteger("State"));
    }

    private bool IsPlayerOnGround()
    {
        return Physics.CheckSphere(groundCheck.position, 0.1f, groundLayer);
    }

    private void MovePlayer()
    {
        movementDirection = (orientation.forward * verticalInput) + (orientation.right * horizontalInput);
        rb.velocity = new Vector3(movementDirection.x * moveSpeed, rb.velocity.y, movementDirection.z * moveSpeed);
    }

}
