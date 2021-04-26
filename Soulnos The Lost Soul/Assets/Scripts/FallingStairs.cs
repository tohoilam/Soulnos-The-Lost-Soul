using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingStairs : MonoBehaviour
{
    public float speed;
    public bool isUpward;

    private float positionOffset;

    // Start is called before the first frame update
    void Start()
    {
        positionOffset = this.transform.localPosition.y;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.localPosition = new Vector3(this.transform.localPosition.x, positionOffset + speed * Time.time, this.transform.localPosition.y);

        if (isUpward)
        {
            if (this.transform.localPosition.y > 3.6)
            {
                positionOffset -= 8.4f;
            }
        }
        else
        {
            if (this.transform.localPosition.y < -3.6)
            {
                positionOffset += 8.4f;
            }
        }
        
    }
}
