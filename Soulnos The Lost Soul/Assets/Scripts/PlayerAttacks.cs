using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AttackMode
{
    Sword,
    FireBall,
}

public class PlayerAttacks : MonoBehaviour
{
    public AttackMode initialAttackMode;
    //public bool killAttackAnimation;

    private PlayerMovementControl playerMovementControlScript;
    private AttackMode currentAttackMode;
    private Animator animator;
    private SpriteRenderer spriteRenderer;


    // Start is called before the first frame update
    void Start()
    {
        currentAttackMode = initialAttackMode;
        animator = this.GetComponent<Animator>();
        spriteRenderer = this.GetComponent<SpriteRenderer>();
        playerMovementControlScript = this.GetComponent<PlayerMovementControl>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("BasicAttack"))
        {
            playerMovementControlScript.isMovementAllowed = false;
            Debug.Log("Disabled Movement");
            if (Input.GetAxis("BasicAttack") > 0)
            {
                spriteRenderer.flipX = false;
            }
            else if (Input.GetAxis("BasicAttack") < 0)
            {
                spriteRenderer.flipX = true;
            }

            switch (currentAttackMode)
            {
                case AttackMode.Sword:
                    animator.SetBool("IsSwordBasic", true);
                    break;
            }
            
        }

        //if (killAttackAnimation)
        //{
        //    Debug.Log("Hi");
        //    FinishAttackAnimation();
        //    playerMovementControlScript.isMovementAllowed = true;
        //    //Debug.Log("Enabled Movement");
        //    killAttackAnimation = false;
        //}
    }

    public void FinishAttackAnimation()
    {
        Debug.Log("Runned");
        switch (currentAttackMode)
        {
            case AttackMode.Sword:
                animator.SetBool("IsSwordBasic", false);
                break;
        }
        playerMovementControlScript.isMovementAllowed = true;
    }
}
