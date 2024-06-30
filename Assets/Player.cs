using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private Player player;

    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float xInput;
    [SerializeField] private bool isGrounded;

    [SerializeField] private bool isMoving;
    private int doubleJump = 0;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();    
        
    }

  
    void Update()
    {
        xInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(xInput * moveSpeed, rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && doubleJump<2)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            doubleJump++;   
        }

        isMoving = rb.velocity.x > 0;
        anim.SetBool("isMoving", isMoving);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            doubleJump=0;
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {

            Time.timeScale = 0;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    
}
