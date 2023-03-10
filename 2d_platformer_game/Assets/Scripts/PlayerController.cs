using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float runSpeed, jumpForce;
    private float jumpHeight = .4f;
    [Range(0, 1)]
    private float moveInput;
    private bool facingRight = true;
    private Rigidbody2D mybody;
    private Animator anim;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public Vector3 range;

    void Awake()
    {
        mybody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        CheckCollusionForJump();
    }
    void FixedUpdate()
    {
        Movement();

    }
    void Movement()
    {
        moveInput = Input.GetAxisRaw("Horizontal") * runSpeed;
        anim.SetFloat("speed", Mathf.Abs(moveInput));
        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (mybody.velocity.y > 0)
            {
                mybody.velocity = new Vector2(mybody.velocity.x, mybody.velocity.y * jumpHeight);
            }
        }


        mybody.velocity = new Vector2(moveInput, mybody.velocity.y);
        if (moveInput > 0 && !facingRight || moveInput < 0 && facingRight)
        {
            Flip();
        }
        if(mybody.velocity.y < 0)
        {
            anim.SetBool("fall", true);
        }
        else
        {
            anim.SetBool("fall", false);
        }
    }
    void CheckCollusionForJump()
    {
        Collider2D bottomHit = Physics2D.OverlapBox(groundCheck.position, range, 0, groundLayer);
        if (bottomHit != null)
        {
            if (bottomHit.gameObject.tag == "Ground" && Input.GetKeyDown(KeyCode.Space))
            {
                mybody.velocity = new Vector2(mybody.velocity.x, jumpForce);
                anim.SetBool("jump",true);

            }
            else
            {
                anim.SetBool("jump", false);
            }
        }

    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawWireCube(groundCheck.position, range);
    }
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 transformScale = transform.localScale;
        transformScale.x *= -1;
        transform.localScale = transformScale;
    }
}

