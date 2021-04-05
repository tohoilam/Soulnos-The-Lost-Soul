using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    public int health;
    [SerializeField] public LayerMask attackLayer;

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collider)
    {
        if (health <= 0)
        {
            animator.SetTrigger("Die");
            Destroy(gameObject);
        }
        
    }
}
