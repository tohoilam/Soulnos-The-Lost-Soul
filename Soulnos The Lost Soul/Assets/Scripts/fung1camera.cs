using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fung1camera : MonoBehaviour
{
    private Vector2 velocity;

    public Transform target;
    public Transform target2;
    public float leftmargin;
    public float rightmargin;
    public float smoothSpeed = 1f;
    void FixedUpdate()
    {
        if ((target.position.x < leftmargin) || (target2.position.x < leftmargin))
        {
            float posX = Mathf.SmoothDamp(transform.position.x, leftmargin, ref velocity.x, smoothSpeed);
            transform.position = new Vector3(posX, 0f, -10);
        }
        else if ((target.position.x > rightmargin) || (target2.position.x > rightmargin))
        {
            float posX = Mathf.SmoothDamp(transform.position.x, rightmargin, ref velocity.x, smoothSpeed);
            transform.position = new Vector3(posX, 0f, -10);
        }

        else
        {
            if (target.position.x > target2.position.x)
            {
                if (target.position.x - target2.position.x < 14)
                {
                    float posX = Mathf.SmoothDamp(transform.position.x, target2.position.x, ref velocity.x, smoothSpeed);
                    transform.position = new Vector3(posX, 0f, -10);
                }
                else
                {
                    float posX = Mathf.SmoothDamp(transform.position.x, (target2.position.x + target.position.x) / 2, ref velocity.x, smoothSpeed);
                    transform.position = new Vector3(posX, 0f, -10);
                }

            }
            else
            {
                if (target2.position.x - target.position.x < 14)
                {
                    float posX = Mathf.SmoothDamp(transform.position.x, target.position.x, ref velocity.x, smoothSpeed);
                    transform.position = new Vector3(posX, 0f, -10);
                }
                else
                {
                    float posX = Mathf.SmoothDamp(transform.position.x, (target2.position.x + target.position.x) / 2, ref velocity.x, smoothSpeed);
                    transform.position = new Vector3(posX, 0f, -10);
                }
            }
        }
    }
}
