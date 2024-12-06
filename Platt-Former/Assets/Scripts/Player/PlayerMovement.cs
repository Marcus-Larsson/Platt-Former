using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float jumpSpeed = 20f;
    [SerializeField] ContactFilter2D groundFilter;

    bool isGrounded;

    Rigidbody2D rb;
    //Collider2D bodyColl;
    Collider2D feetColl;
    Vector2 moveInput;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //bodyColl = GetComponent<CapsuleCollider2D>();
        feetColl = GetComponent<BoxCollider2D>();
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void OnJump()
    {
        if (isGrounded)
        {
            rb.AddForce(Vector2.up * jumpSpeed);
            rb.velocity += new Vector2(0f, jumpSpeed);
        }
    }

    void Run()
    {
        Vector2 playerVelocity = new Vector2(moveInput.x * moveSpeed, rb.velocity.y);
        rb.velocity = playerVelocity;

        if (moveInput.x != 0)
        {
            transform.localScale = new Vector2(Mathf.Sign(moveInput.x), transform.localScale.y);
        }
    }

    void Update()
    {
        Run();
        CheckIfGrounded();
    }

    void CheckIfGrounded()
    {
        isGrounded = feetColl.IsTouching(groundFilter);
    }

    private void FixedUpdate()
    {
        isGrounded = rb.IsTouching(groundFilter);
    }
}



 