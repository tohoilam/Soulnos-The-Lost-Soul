using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothFollow : MonoBehaviour
{
    private Vector2 velocity;

    public Transform target;
    public Transform target2;
    public float smoothSpeed = 0.125f;
    void FixedUpdate()
    {
        if ((target.position.x < -3.27) && (target2.position.x < -3.27))
        {
            float posX = Mathf.SmoothDamp(transform.position.x, -3.27f, ref velocity.x, smoothSpeed);
            transform.position = new Vector3(posX, 0.36f, -10);
        }
        else if ((target.position.x > -3.87) && (target2.position.x > -3.87))
        {
            float posX = Mathf.SmoothDamp(transform.position.x, 3.87f, ref velocity.x, smoothSpeed);
            transform.position = new Vector3(posX, 0.36f, -10);
        }

        else
        {
            if (target.position.x > target2.position.x)
            {
                if (target.position.x - target2.position.x < 14)
                {
                    float posX = Mathf.SmoothDamp(transform.position.x, target2.position.x, ref velocity.x, smoothSpeed);
                    transform.position = new Vector3(posX, 0.36f, -10);
                }
                else
                {
                    float posX = Mathf.SmoothDamp(transform.position.x, (target2.position.x + target.position.x) / 2, ref velocity.x, smoothSpeed);
                    transform.position = new Vector3(posX, 0.36f, -10);
                }

            }
            else
            {
                if (target2.position.x - target.position.x < 14)
                {
                    float posX = Mathf.SmoothDamp(transform.position.x, target.position.x, ref velocity.x, smoothSpeed);
                    transform.position = new Vector3(posX, 0.36f, -10);
                }
                else
                {
                    float posX = Mathf.SmoothDamp(transform.position.x, (target2.position.x + target.position.x) / 2, ref velocity.x, smoothSpeed);
                    transform.position = new Vector3(posX, 0.36f, -10);
                }
            }
        }
    }
}
