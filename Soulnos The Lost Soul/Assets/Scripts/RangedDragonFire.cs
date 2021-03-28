using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedDragonFire : MonoBehaviour
{
    public int firetime;
    public bool negativeGravity;
    public bool flipDirection;
    public GameObject DragonFire;
    private int counter;

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
    }


    void Update()
    {
        counter -= 1;
        if (counter < 0){
            animator.SetTrigger("Fire");
            int direction = (spriteRenderer.flipX) ? -1 : 1;
            GameObject newObject = Instantiate(DragonFire, this.transform.position + new Vector3(direction*0.5f, -0.3f + rangeCastOffset, 0), Quaternion.identity) as GameObject;
            newObject.GetComponent<Rigidbody2D>().velocity = new Vector2(3 * direction, 0);
            counter = firetime;

        }
    }


}
