using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{

    public float speed;
    public float jumpForce;
    private float moveInput;
    private bool facingRight = true;
    public Rigidbody2D rb;

    private bool isGrounded;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;

    private Animator anim;





    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        if(facingRight == false && moveInput > 0)
            Flip();

        if(facingRight == true && moveInput < 0)
            Flip();

        if (moveInput == 0)
        {
            anim.SetBool("isRun", false);
        }

        else
        {
            anim.SetBool("isRun", true);
        }
            
    }
    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);
    
        if(isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector2.up * jumpForce;
            
        }
        if(isGrounded == true)
        {
            anim.SetBool("isJump", false);
        }
        else
        {
            anim.SetBool("isJump", true);
        }

      
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("platform_moving"))
        {
            this.transform.parent = collision.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("platform_moving"))
        {
            this.transform.parent = null;
        }
    }


}
