using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementControl : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public bool negativeGravity;
    public bool isMovementAllowed;

    [SerializeField] private LayerMask groundLayerMask;

    private new Rigidbody2D rigidbody;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private float horizontalInput;
    private bool activateJump;
    private bool isGrounded;
    private int gravityScale;

    // Start is called before the first frame update
    void Start()
    {
        isGrounded = false;
        activateJump = false;
        isMovementAllowed = true;

        rigidbody = this.GetComponent<Rigidbody2D>();
        spriteRenderer = this.GetComponent<SpriteRenderer>();
        animator = this.GetComponent<Animator>();

        if (negativeGravity)
        {
            gravityScale = -1;
        }
        else
        {
            gravityScale = 1;
        }
        this.rigidbody.gravityScale *= gravityScale;
    }

    void OnCollisionStay(Collision collision)
    {
        isGrounded = true;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = 0;
        if (isMovementAllowed)
        {
            horizontalInput = Input.GetAxis("Horizontal");
            if (horizontalInput > 0)
            {
                spriteRenderer.flipX = false;
            }
            else if (horizontalInput < 0)
            {
                spriteRenderer.flipX = true;
            }

            if (isGrounded && Input.GetButtonDown("Jump"))
            {
                activateJump = true;
            }
        }
        

        animator.SetFloat("Speed", Mathf.Abs(rigidbody.velocity.x));

    }

    private void FixedUpdate()
    {
        this.rigidbody.velocity = new Vector2(speed * horizontalInput, rigidbody.velocity.y);
        animator.SetFloat("Speed", Mathf.Abs(rigidbody.velocity.x));
        
        if (activateJump)
        {
            animator.SetBool("IsJumping", true);
            this.rigidbody.AddForce(new Vector2(0.0f, 1.0f) * jumpForce * gravityScale, ForceMode2D.Impulse);
            activateJump = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("Can Jump");
        if (collider != null)
        {
            if (((1 << collider.gameObject.layer) & groundLayerMask) != 0)
            {
                isGrounded = true;
                animator.SetBool("IsJumping", false);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        isGrounded = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //Debug.Log("Colliding");
    }
}
