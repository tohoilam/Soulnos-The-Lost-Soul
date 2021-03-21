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
    //public enum AttackMode { Sword, FireBall };
    public AttackModeClass.AttackMode initialAttackMode;
    public bool isAttackDirectionRight;
    //public bool killAttackAnimation;

    private PlayerMovementControl playerMovementControlScript;
    private AttackModeClass.AttackMode currentAttackMode;
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
        GameObject.Find("RealityPlayerSwordAttackRight").GetComponent<CircleCollider2D>().enabled = false;
        GameObject.Find("RealityPlayerSwordAttackLeft").GetComponent<CircleCollider2D>().enabled = false;
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
                case AttackModeClass.AttackMode.Sword:
                    animator.SetTrigger("IsSwordBasic");
                    break;
                case AttackModeClass.AttackMode.FireBall:
                    animator.SetTrigger("IsFireCasting");
                    break;
            }
            
        }
    }

    public void FinishAttackAnimation()
    {
        playerMovementControlScript.isMovementAllowed = true;
    }

    public void TriggerSowrdCollision()
    {
        isSwordTriggerAllowed = true;
        GameObject.Find("RealityPlayerSwordAttackRight").GetComponent<CircleCollider2D>().enabled = true;
        GameObject.Find("RealityPlayerSwordAttackLeft").GetComponent<CircleCollider2D>().enabled = true;
        //this.gameObject.transform.GetChild(1).GetComponent<CircleCollider2D>().enabled = true;
        //this.gameObject.transform.GetChild(2).GetComponent<CircleCollider2D>().enabled = true;
    }

    public AttackModeClass.AttackMode getCurrentAttackMode()
    {
        return this.currentAttackMode;
    }

    public void setCurrentAttackMode(AttackModeClass.AttackMode newAttackMode)
    {
        this.currentAttackMode = newAttackMode;
    }
}
