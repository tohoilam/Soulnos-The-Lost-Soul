using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    void FixedUpdate()
    {
        this.transform.position = new Vector3(GameObject.Find("Main Camera").transform.position.x, transform.position.y, transform.position.z);

    }
}
