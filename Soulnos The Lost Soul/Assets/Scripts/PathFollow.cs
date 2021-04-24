using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollow : MonoBehaviour
{
    PathNode[] pathNode;

    private GameObject trap;
    public float speed;
    float timer;
    int currentNode;
    Vector3 currentPositionHolder;


    // Start is called before the first frame update
    void Start()
    {
        currentNode = 0;
        trap = this.transform.parent.GetChild(0).gameObject;
        CheckNode();

        trap.transform.position = currentPositionHolder;
    }

    void CheckNode()
    {
        if (currentNode < this.transform.childCount)
        {
            timer = 0;
            currentPositionHolder = this.transform.GetChild(currentNode).transform.position;
        }
            
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime * speed;

        if (trap.transform.position != currentPositionHolder)
        {
            trap.transform.position = Vector3.Lerp(trap.transform.position, currentPositionHolder, timer);
        }
        else
        {
            currentNode = (currentNode < this.transform.childCount) ? currentNode + 1 : 0;

            CheckNode();
        }
    }
}
