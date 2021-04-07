using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public GameObject clearedText;
    public float textDelayTime;

    [SerializeField] private LayerMask groundLayerMask;

    private Animator animator;
    private float clearedTime;
    private bool isCleared;
    private bool textInstantiated;

    // Start is called before the first frame update
    void Start()
    {
        animator = this.gameObject.GetComponent<Animator>();
        isCleared = false;
        textInstantiated = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isCleared)
        {
            if (!textInstantiated && Time.time >= clearedTime + textDelayTime)
            {
                Instantiate(clearedText);
                textInstantiated = true;
                Time.timeScale = 0;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            if (((1 << collision.gameObject.layer) & groundLayerMask) != 0)
            {
                animator.SetTrigger("TouchFlag");
                isCleared = true;
                clearedTime = Time.time;
                
            }
        }
    }
}
