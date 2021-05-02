using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class RangedDragonFire : MonoBehaviour
{
    public float firetime;
    public bool negativeGravity;
    public bool flipDirection;
    public GameObject DragonFire;
    private int counter;
    private float LastFireTime;

    [SerializeField] private LayerMask groundLayerMask;

    private new Rigidbody2D rigidbody;
    private Animator animator;
    private int gravityScale;
    private SpriteRenderer spriteRenderer;
    private float rangeCastOffset; 

    void Start()
    {
        rigidbody = this.GetComponent<Rigidbody2D>();
        animator = this.GetComponent<Animator>();
        spriteRenderer = this.GetComponent<SpriteRenderer>();
        rangeCastOffset = negativeGravity ? 0.6f : 0.0f;
        if (flipDirection)
        {
            spriteRenderer.flipX = true;
        }
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
        LastFireTime = Time.time;
    }


    void Update()
    {
        if (Time.time > LastFireTime + firetime)
        {
            fire();
        }
    }

    void fire()
    {
        animator.SetTrigger("Fire");
        int direction = (spriteRenderer.flipX) ? -1 : 1;
        GameObject newObject = Instantiate(DragonFire, this.transform.position + new Vector3(direction * 0.5f, -0.3f + rangeCastOffset, 0), Quaternion.identity) as GameObject;
        newObject.GetComponent<Rigidbody2D>().velocity = new Vector2(3 * direction, 0);
        LastFireTime = Time.time;
        

    }


}
