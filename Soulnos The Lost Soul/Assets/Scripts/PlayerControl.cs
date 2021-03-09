using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float speed;
    public float jumpForce;

    bool isGrounded;
    new Rigidbody2D rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        isGrounded = false;
        rigidbody = this.GetComponent<Rigidbody2D>();
    }

    void OnCollisionStay(Collision collision)
    {
        isGrounded = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            this.transform.Translate(Time.deltaTime * speed, 0, 0);
        }

        if (Input.GetKey(KeyCode.A))
        {
            this.transform.Translate(-Time.deltaTime * speed, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.Space) && !isGrounded)
        {
            this.rigidbody.AddForce(new Vector3(0.0f, 1.0f, 0.0f) * jumpForce, ForceMode2D.Impulse);
        }
    }
}
