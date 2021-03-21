using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesTrigger : MonoBehaviour
{
    [SerializeField] public LayerMask attackLayer;
    public GameObject realityPlayerObject;
    public GameObject voidPlayerObject;

    private Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        animator = this.transform.parent.GetComponent<Animator>();
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
            if (collision.gameObject == realityPlayerObject.transform.GetChild(1))
            {
                GameObject.Find("RealityPlayerSwordAttackRight").GetComponent<CircleCollider2D>().enabled = false;
            }
            else if (collision.gameObject == realityPlayerObject.transform.GetChild(2))
            {
                GameObject.Find("RealityPlayerSwordAttackLeft").GetComponent<CircleCollider2D>().enabled = false;
            }
            else if (collision.gameObject == voidPlayerObject.transform.GetChild(1))
            {
                voidPlayerObject.transform.GetChild(1).GetComponent<CircleCollider2D>().enabled = false;
            }
            else if (collision.gameObject == voidPlayerObject.transform.GetChild(2))
            {
                voidPlayerObject.transform.GetChild(2).GetComponent<CircleCollider2D>().enabled = false;
            }
        }
        
    }
}
