using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConvertAttackMode : MonoBehaviour
{
    public AttackModeClass.AttackMode attackMode;
    public GameObject realityPlayerObject;
    public GameObject voidPlayerObject;
    [SerializeField] public LayerMask playerLayer;

    private PlayerAttacks playerAttacksScript;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == (int)Mathf.Log(playerLayer.value, 2))
        {
            
            if (collision.gameObject == realityPlayerObject)
            {
                realityPlayerObject.GetComponent<PlayerAttacks>().setCurrentAttackMode(attackMode);
                Destroy(gameObject);
            }
            else if (collision.gameObject == voidPlayerObject)
            {
                voidPlayerObject.GetComponent<PlayerAttacks>().setCurrentAttackMode(attackMode);
                Destroy(gameObject);
            }
                
        }
    }
}
