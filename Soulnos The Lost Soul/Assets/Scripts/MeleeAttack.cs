using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    [SerializeField] private LayerMask enemyLayerMask;

    public bool isRightTriggerObject;

    private PlayerAttacks playerAttacksScript;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        playerAttacksScript = this.gameObject.transform.parent.gameObject.GetComponent<PlayerAttacks>();
        animator = this.gameObject.transform.parent.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //private void OnTriggerStay2D(Collider2D collider)
    //{
    //    if (playerAttacksScript.isSwordTriggerAllowed && isRightTriggerObject == playerAttacksScript.isAttackDirectionRight && collider != null)
    //    {
    //        if (((1 << collider.gameObject.layer) & enemyLayerMask) != 0)
    //        {

    //            Debug.Log("hit");
    //            //animator.SetTrigger("IsHurt");
    //        }
    //    }
    //    //playerAttacksScript.isSwordTriggerAllowed = false;
    //}

}
