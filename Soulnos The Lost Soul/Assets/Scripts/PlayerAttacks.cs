using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public enum AttackMode
//{
//    Sword,
//    FireBall,
//}

public class PlayerAttacks : MonoBehaviour
{
    public enum AttackMode { Sword, FireBall };
    public AttackMode initialAttackMode;
    public bool isAttackDirectionRight;
    //public bool killAttackAnimation;

    private PlayerMovementControl playerMovementControlScript;
    private AttackMode currentAttackMode;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    public bool isSwordTriggerAllowed;


    // Start is called before the first frame update
    void Start()
    {
        currentAttackMode = initialAttackMode;
        animator = this.GetComponent<Animator>();
        spriteRenderer = this.GetComponent<SpriteRenderer>();
        playerMovementControlScript = this.GetComponent<PlayerMovementControl>();
        isSwordTriggerAllowed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("BasicAttack"))
        {
            playerMovementControlScript.isMovementAllowed = false;
            if (Input.GetAxis("BasicAttack") > 0)
            {
                spriteRenderer.flipX = false;
                isAttackDirectionRight = true;
            }
            else if (Input.GetAxis("BasicAttack") < 0)
            {
                spriteRenderer.flipX = true;
                isAttackDirectionRight = false;
            }

            switch (currentAttackMode)
            {
                case AttackMode.Sword:
                    animator.SetBool("IsSwordBasic", true);
                    break;
            }
            
        }
    }

    public void FinishAttackAnimation()
    {
        switch (currentAttackMode)
        {
            case AttackMode.Sword:
                animator.SetBool("IsSwordBasic", false);
                break;
        }
        playerMovementControlScript.isMovementAllowed = true;
    }

    public void TriggerSowrdCollision()
    {
        isSwordTriggerAllowed = true;
    }
}
