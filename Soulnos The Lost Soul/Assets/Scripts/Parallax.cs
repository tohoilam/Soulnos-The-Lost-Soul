using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public float startingPosition;
    public float width;
    public float speed;

    //Start is called before the first frame update
    void Start()
    {
        startingPosition = this.transform.position.x;
        width = this.GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.transform.position = new Vector3(this.transform.position.x + speed, transform.position.y, transform.position.z);

        if (this.transform.position.x > width || this.transform.position.x < -1 * width)
        {
            this.transform.position = new Vector3(startingPosition, this.transform.position.y, this.transform.position.z);
            
        }
    }
}
