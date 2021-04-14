using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class NinjaMovement : MonoBehaviour
{
    [SerializeField] public LayerMask groundLayer;
    [SerializeField] public LayerMask playerLayer;
    public float speed;
    public bool negativeGravity;

    [SerializeField] private LayerMask groundLayerMask;

    private new Rigidbody2D rigidbody;
    private SpriteRenderer spriteRenderer;
    private int gravityScale;
    private Animator animator;

    void Start()
    {
        animator = this.transform.GetComponent<Animator>();
        rigidbody = this.GetComponent<Rigidbody2D>();
        spriteRenderer = this.GetComponent<SpriteRenderer>();
        spriteRenderer.flipX = false;
        this.rigidbody.velocity = new Vector2(speed, rigidbody.velocity.y);
        if (negativeGravity)
        {
            gravityScale = -1;
            this.transform.localScale = new Vector3(0.5f, -0.5f, 1);
        }
        else
        {
            gravityScale = 1;
        }
        this.rigidbody.gravityScale *= gravityScale;
    }


    void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj != null)
        {
            if (((1 << obj.gameObject.layer) & groundLayerMask) != 0)
            {
                if (obj.gameObject.layer == (int)Mathf.Log(groundLayer.value, 2))
                {
                    flip();
                }
                 else if (obj.gameObject.layer == (int)Mathf.Log(playerLayer.value, 2))
                {
                    this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
                    animator.SetTrigger("Attack");
                }
            }
        }
    }
    public void flip()
    {
        this.rigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
        if (spriteRenderer.flipX == false)
        {
            spriteRenderer.flipX = true;
            this.rigidbody.velocity = new Vector2(speed * -1, 0);
        }
        else if (spriteRenderer.flipX == true)
        {
            spriteRenderer.flipX = false;
            this.rigidbody.velocity = new Vector2(speed, rigidbody.velocity.y);
        }
    }
    public void UnfreezePosition()
    {
        this.rigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
        if (spriteRenderer.flipX == true)
        {
            this.rigidbody.velocity = new Vector2(speed * -1, 0);
        }
        else
        {
            this.rigidbody.velocity = new Vector2(speed, rigidbody.velocity.y);
        }
    }

}
