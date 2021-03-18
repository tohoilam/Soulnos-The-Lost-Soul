using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeAttack : MonoBehaviour
{
    public GameObject fireball;
    //public bool isAttackDirectionRight;

    private PlayerMovementControl playerMovementControlScript;

    // Start is called before the first frame update
    void Start()
    {
        playerMovementControlScript = this.transform.parent.GetComponent<PlayerMovementControl>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("BasicAttack"))
        {
            playerMovementControlScript.isMovementAllowed = false;
            //if (Input.GetAxis("BasicAttack") > 0)
            //{
            //    isAttackDirectionRight = true;
            //}
            //else if (Input.GetAxis("BasicAttack") < 0)
            //{
            //    isAttackDirectionRight = false;
            //}

            Instantiate(fireball, this.transform.position + new Vector3(0, -0.3f, 0), Quaternion.identity);

        }
    }
}
