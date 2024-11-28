using System;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D body;
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    private Animator animator;
    private BoxCollider2D boxCollider;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask wallLayer;
    private float horizontalInput;

    private float wallJumpCoolDown;
    
    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        if (horizontalInput > 0.01f)
        {
            transform.localScale = Vector3.one * 5f;
        }else if (horizontalInput < -0.01f)
        {
            transform.localScale = new Vector3(-5, 5, 5);
        }
        
        animator.SetBool("run", horizontalInput != 0);
        animator.SetBool("onGround", isOnGround());

        if (wallJumpCoolDown > 0.1f)
        {
            body.velocity = new Vector2(horizontalInput*speed, body.velocity.y);
            
            if(onWall() && !isOnGround())
            {
                body.gravityScale = 0;
                body.velocity = Vector2.zero;
            }
            else
            {
                body.gravityScale = 3;
            }
            
            if (Input.GetKey(KeyCode.Space))
            {
                Jump();
            }
        }
        else
        {
            wallJumpCoolDown += Time.deltaTime;
        }

        print(onWall());
    }

    private void Jump()
    {
        if (isOnGround())
        {
            body.velocity = new Vector2(body.velocity.x, jumpForce);
            animator.SetTrigger("jump");
        }else if (onWall() && !isOnGround())
        {
            if (horizontalInput == 0)
            {
                body.velocity = new Vector2(-Math.Sign(transform.localScale.x) * 10, 0);
                //pushing back??? do we really need this? (*5 bec initial scale is 5, 5, 5)
                transform.localScale = new Vector3(-Math.Sign(transform.localScale.x) * 5, transform.localScale.y, transform.localScale.z);
            }
            else
            {
                body.velocity = new Vector2(-Math.Sign(transform.localScale.x) * 3, 6);
            }
            wallJumpCoolDown = 0;
            
        }
    }

    private bool isOnGround()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }
    
    private bool onWall()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, new Vector2(transform.localScale.x, 0), 0.1f, wallLayer);
        return raycastHit.collider != null;
    }
}
