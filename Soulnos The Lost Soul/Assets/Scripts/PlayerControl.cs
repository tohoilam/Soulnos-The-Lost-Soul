using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float speed;
    public float jumpForce;

    bool isGrounded;
    new Rigidbody2D rigidbody;
    SpriteRenderer spriteRenderer;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        isGrounded = false;
        rigidbody = this.GetComponent<Rigidbody2D>();
        spriteRenderer = this.GetComponent<SpriteRenderer>();
        animator = this.GetComponent<Animator>();

    }

    void OnCollisionStay(Collision collision)
    {
        isGrounded = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            spriteRenderer.flipX = false;
            //this.rigidbody.MovePosition(transform.position + (Time.deltaTime * speed * new Vector3(1.0f, 0.0f, 0.0f)));
            //this.transform.Translate(Time.deltaTime * speed, 0, 0);
            this.rigidbody.velocity = new Vector2(speed, rigidbody.velocity.y);
        }

        if (Input.GetKey(KeyCode.A))
        {
            spriteRenderer.flipX = true;
            //this.rigidbody.MovePosition(transform.position + (Time.deltaTime * -speed * new Vector3(1.0f, 0.0f, 0.0f)));
            //this.transform.Translate(-Time.deltaTime * speed, 0, 0);
            this.rigidbody.velocity = new Vector2(-speed, rigidbody.velocity.y);
        }

        if (Input.GetKeyDown(KeyCode.Space) && !isGrounded)
        {
            this.rigidbody.AddForce(new Vector3(0.0f, 1.0f, 0.0f) * jumpForce, ForceMode2D.Impulse);
        }

        animator.SetFloat("Speed", Mathf.Abs(rigidbody.velocity.x));
        
    }
}
