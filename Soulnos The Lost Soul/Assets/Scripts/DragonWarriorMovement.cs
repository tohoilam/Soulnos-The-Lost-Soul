using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonWarriorMovement : MonoBehaviour
{
    public float speed;
    public bool negativeGravity;

    [SerializeField] private LayerMask groundLayerMask;

    private new Rigidbody2D rigidbody;
    private SpriteRenderer spriteRenderer;
    private int gravityScale;

    void Start()
    {
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
        }
    }



}
