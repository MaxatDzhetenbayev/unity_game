using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySlimeController : MonoBehaviour
{


    private bool facingRight = false;
    [SerializeField] LayerMask whatIsGround;

    private bool isGround = false;
    private bool isFalling = false;
    private bool isJumping = false;

    private float jumpForceX = 2f;
    private float jumpForceY = 4f;

    private float lastPos = 0;

    public enum Animations
    {
        Idle = 0,
        Jumping = 1,
        Falling = 2

    };

    public Animations currentAnim;

    public Rigidbody2D rb;
    public SpriteRenderer spriteRenderer;
    public Animator anim;

    public float idleTime = 2f;
    private float currentIdleTime = 0;
    private bool isIdle = true;



    // Start is called before the first frame update
    void Start()
    {
        lastPos = transform.position.y;
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (isIdle)
        {
            currentIdleTime += Time.deltaTime;
            if(currentIdleTime >= idleTime)
            {
               
                currentIdleTime = 0;
                facingRight = !facingRight;
                spriteRenderer.flipX = facingRight;
                Jump();
            }
        }

        isGround = Physics2D.OverlapArea(new Vector2(transform.position.x - 0.5f, transform.position.y - 0.5f),
            new Vector2(transform.position.x + 0.5f, transform.position.y - 0.5f), whatIsGround);

        if(isGround && isFalling)
        {
            isFalling = false;
            isJumping = false;
            isIdle = true;
            ChangeAnimation(Animations.Idle);
        }
        else if(transform.position.y > lastPos && !isGround && !isIdle)
        {
            isJumping = true;
            isFalling = false;
            ChangeAnimation(Animations.Jumping);
        }
        else if (transform.position.y < lastPos && !isGround && !isIdle)
        {
            isJumping = false;
            isFalling = true;
            ChangeAnimation(Animations.Falling);
        }

        lastPos = transform.position.y;
    }


    void Jump()
    {
        isJumping = true;
        isIdle = false;
        int direction = 0;
        if (facingRight == true)
        {
            direction = 1;
        }
        else
        {
            direction = -1;
        }
        rb.velocity = new Vector2(jumpForceX * direction, jumpForceY);

    }

    void ChangeAnimation(Animations newAnim)
    {
        if(currentAnim != newAnim)
        {
            currentAnim = newAnim;
            anim.SetInteger("state", (int)newAnim);
        }
    }
}
