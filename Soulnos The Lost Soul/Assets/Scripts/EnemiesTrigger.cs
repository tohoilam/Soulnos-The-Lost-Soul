using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesTrigger : MonoBehaviour
{
    [SerializeField] public LayerMask attackLayer;
    public GameObject realityPlayerObject;
    public GameObject voidPlayerObject;
    public float maxhealth;
    private float health;

    private GameObject realityPlayerSwordAttackRight;
    private GameObject realityPlayerSwordAttackLeft;
    private GameObject voidPlayerSwordAttackRight;
    private GameObject voidPlayerSwordAttackLeft;

    private Animator animator;

    public bool isRunningDragonWarrior;
    private new Rigidbody2D rigidbody2D;


    // Start is called before the first frame update
    void Start()
    {
        animator = this.transform.parent.GetComponent<Animator>();
        realityPlayerSwordAttackRight = GameObject.Find("RealityPlayerSwordAttackRight");
        realityPlayerSwordAttackLeft = GameObject.Find("RealityPlayerSwordAttackLeft");
        voidPlayerSwordAttackRight = GameObject.Find("VoidPlayerSwordAttackRight");
        voidPlayerSwordAttackLeft = GameObject.Find("VoidPlayerSwordAttackLeft");
        health = maxhealth;


        this.rigidbody2D = this.transform.parent.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == (int)Mathf.Log(attackLayer.value, 2))
        {
            this.rigidbody2D.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;

            health -= 2;

            if (health < 0)
            {
                health = 0;
            }

            this.transform.parent.transform.Find("EnemyHealthBar").transform.Find("EnemyHealthBar").transform.Find("Health").transform.localScale = new Vector3((health/maxhealth), 1, 1);
            this.transform.parent.transform.Find("EnemyHealthBar").transform.Find("EnemyHealthBar").transform.Find("Health").transform.localPosition = new Vector3((1-(health / maxhealth))*-2, 0, 0);

            if (health <= 0)
            {
                animator.SetTrigger("Die");
                Destroy(transform.parent.gameObject,0.833f);
            }
            animator.SetTrigger("IsHurt");
            
            if (collision.gameObject == realityPlayerSwordAttackRight)
            {
                realityPlayerSwordAttackRight.GetComponent<CircleCollider2D>().enabled = false;
            }
            else if (collision.gameObject == realityPlayerSwordAttackLeft)
            {
                realityPlayerSwordAttackLeft.GetComponent<CircleCollider2D>().enabled = false;
            }
            else if (collision.gameObject == voidPlayerSwordAttackRight)
            {
                voidPlayerSwordAttackRight.GetComponent<CircleCollider2D>().enabled = false;
            }
            else if (collision.gameObject == voidPlayerSwordAttackLeft)
            {
                voidPlayerSwordAttackLeft.GetComponent<CircleCollider2D>().enabled = false;
            }
        }
        
    }

    public void UnfreezePosition()
    {
        if (isRunningDragonWarrior)
        {
            this.gameObject.transform.parent.GetComponent<DragonWarriorMovement>().UnfreezePosition();
        }
    }
}
