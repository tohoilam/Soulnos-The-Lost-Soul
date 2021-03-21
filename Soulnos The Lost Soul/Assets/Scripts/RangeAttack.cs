using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeAttack : MonoBehaviour
{
    public GameObject fireball;
    //public bool isAttackDirectionRight;

    private PlayerMovementControl playerMovementControlScript;
    private PlayerAttacks playerAttacksScript;

    // Start is called before the first frame update
    void Start()
    {
        playerMovementControlScript = this.transform.parent.GetComponent<PlayerMovementControl>();
        playerAttacksScript = this.transform.parent.GetComponent<PlayerAttacks>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("BasicAttack"))
        {
            if (playerAttacksScript.getCurrentAttackMode() == AttackModeClass.AttackMode.FireBall)
            {
                playerMovementControlScript.isMovementAllowed = false;

                Instantiate(fireball, this.transform.position + new Vector3(0, -0.3f, 0), Quaternion.identity);
            }
            

        }
    }
}
