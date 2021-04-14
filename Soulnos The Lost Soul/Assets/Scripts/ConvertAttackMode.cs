using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConvertAttackMode : MonoBehaviour
{
    public AttackModeClass.AttackMode attackMode;
    [SerializeField] public LayerMask playerLayer;

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
            collision.gameObject.GetComponent<PlayerAttacks>().setCurrentAttackMode(attackMode);
            Destroy(gameObject);
                
        }
    }
}
