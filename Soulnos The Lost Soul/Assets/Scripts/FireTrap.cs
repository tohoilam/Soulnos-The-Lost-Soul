using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTrap : MonoBehaviour
{
    public float offTime;
    public float onTime;

    private bool isOn;
    private float setTime;
    private Animator animator;
    private BoxCollider2D boxCollider;

    // Start is called before the first frame update
    void Start()
    {
        boxCollider = this.transform.GetChild(0).gameObject.GetComponent<BoxCollider2D>();

        isOn = false;
        //boxCollider.enabled = false;
        setTime = Time.time;
        animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isOn)
        {
            if (Time.time > setTime + onTime)
            {
                isOn = false;
                animator.SetBool("IsOn", false);
                setTime = Time.time;
                boxCollider.enabled = false;
            }
        }
        else
        {
            if (Time.time > setTime + offTime)
            {
                isOn = true;
                animator.SetBool("IsOn", true);
                setTime = Time.time;
                boxCollider.enabled = true;
            }
        }
    }
}
