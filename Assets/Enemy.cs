using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private bool isGrounded;
    [SerializeField] private float moveSpeed;
    [SerializeField] private int rightSide;
    [SerializeField] protected int playerPoints;
    protected Vector2 startPosition;

    [SerializeField] UnityEvent onTriggerEnter;
    [SerializeField] UnityEvent onTriggerExit;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (isGrounded && rightSide != 1)
        {
            rb.velocity = Vector2.right * moveSpeed;
        }
        else if(isGrounded && rightSide == 1)
        {
            rb.velocity = Vector2.left * moveSpeed;
        }

        if(transform.position.x > 22 && rightSide != 1)
        {
            transform.position = startPosition;
        }
        if (transform.position.x < -22 && rightSide == 1)
        {
            transform.position = startPosition;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        onTriggerEnter.Invoke();
        transform.position = startPosition;
        Debug.Log("Punkt!");

        playerPoints++;


    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        onTriggerExit.Invoke();
    }
}
