using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public bool positiveDirection;
    public int speed;
    //public GameObject player;

    private int direction;

    // Start is called before the first frame update
    void Start()
    {
        positiveDirection = GameObject.Find("RealityPlayer").GetComponent<PlayerAttacks>().isAttackDirectionRight;

        direction = (positiveDirection) ? 1 : -1;
        if (!positiveDirection)
        {
            this.GetComponent<SpriteRenderer>().flipX = true;
        }

        Rigidbody2D rigidbody2D = this.GetComponent<Rigidbody2D>();
        rigidbody2D.velocity = new Vector2(speed * direction, 0);
    }

    // Update is called once per frame
    void Update()
    {
        //this.transform.position = new Vector2(Time.deltaTime * direction * speed, 0.0f);
    }
}
