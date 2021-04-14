using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    [SerializeField] private LayerMask groundLayerMask;

    private Animator animator;
    private bool collided;

    // Start is called before the first frame update
    void Start()
    {
        animator = this.gameObject.GetComponent<Animator>();
        collided = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && !collided)
        {
            if (((1 << collision.gameObject.layer) & groundLayerMask) != 0)
            {
                animator.SetTrigger("TouchFlag");

                collision.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX;
                collision.gameObject.GetComponent<PlayerMovementControl>().enabled = false;
                collision.gameObject.GetComponent<PlayerAttacks>().enabled = false;
                collision.gameObject.GetComponent<PlayerStatistics>().enabled = false;
                collision.gameObject.GetComponent<Animator>().SetBool("IsIdle", true);

                this.transform.parent.GetComponent<GameManagement>().goalReachedCount++;

                collided = true;


                
            }
        }
    }
}
