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
    static Vector3 currentPositionHolder;


    // Start is called before the first frame update
    void Start()
    {
        currentNode = 0;
        pathNode = GetComponentsInChildren<PathNode>();
        trap = this.transform.parent.GetChild(0).gameObject;
        CheckNode();

        trap.transform.position = currentPositionHolder;
    }

    void CheckNode()
    {
        if (currentNode < pathNode.Length)
        {
            timer = 0;
            currentPositionHolder = pathNode[currentNode].transform.position;
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
            currentNode = (currentNode < pathNode.Length) ? currentNode + 1 : 0;
            
            CheckNode();
        }
    }
}
