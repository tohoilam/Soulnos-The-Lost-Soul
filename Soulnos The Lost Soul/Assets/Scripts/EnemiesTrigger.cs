using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesTrigger : MonoBehaviour
{
    [SerializeField] public LayerMask attackLayer;
    public GameObject realityPlayerObject;
    public GameObject voidPlayerObject;

    private GameObject realityPlayerSwordAttackRight;
    private GameObject realityPlayerSwordAttackLeft;
    private GameObject voidPlayerSwordAttackRight;
    private GameObject voidPlayerSwordAttackLeft;

    private Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        animator = this.transform.parent.GetComponent<Animator>();
        realityPlayerSwordAttackRight = GameObject.Find("RealityPlayerSwordAttackRight");
        realityPlayerSwordAttackLeft = GameObject.Find("RealityPlayerSwordAttackLeft");
        voidPlayerSwordAttackRight = GameObject.Find("VoidPlayerSwordAttackRight");
        voidPlayerSwordAttackLeft = GameObject.Find("VoidPlayerSwordAttackLeft");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == (int)Mathf.Log(attackLayer.value, 2))
        {
            Debug.Log("Hurt");
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
}
