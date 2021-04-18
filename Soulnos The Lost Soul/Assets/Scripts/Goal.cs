using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    [SerializeField] private LayerMask groundLayerMask;
    public bool isVoidGate;

    private bool collided;
    private GameObject playerObject;
    private float delayWalk = 0.5f;
    private float arrivedTime;
    private bool arrivedCenter;
    private float walkingSpeed = 0.005f;
    //private float delayDestroy = 2f;
    //private float arrivedCenterTime;

    // Start is called before the first frame update
    void Start()
    {
        collided = false;
        arrivedCenter = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (collided && Time.time > arrivedTime + delayWalk && !arrivedCenter)
        {
            int directionPositive;
            if (this.transform.position.x > playerObject.transform.position.x)
            {
                directionPositive = 1;
            }
            else
            {
                directionPositive = -1;
            }
            playerObject.transform.position += new Vector3(directionPositive * walkingSpeed, 0f, 0f);
            if (Mathf.Abs(this.transform.position.x - playerObject.transform.position.x) < walkingSpeed + 0.001f)
            {
                arrivedCenter = true;
                //arrivedCenterTime = Time.time;

                playerObject.GetComponent<Animator>().SetBool("IsIdle", true);
                playerObject.GetComponent<Animator>().SetBool("IsRunningToGoal", false);

                playerObject.transform.GetChild(3).gameObject.SetActive(false);
            }
                
        }

        if (arrivedCenter)
        {
            if (playerObject.GetComponent<SpriteRenderer>().color.a != 0)
            {
                playerObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, playerObject.GetComponent<SpriteRenderer>().color.a - 0.01f);

            }
        }

        //if (arrivedCenter && Time.time > arrivedCenterTime + delayDestroy)
        //{
        //    Destroy(playerObject);
        //}
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && !collided)
        {
            if (((1 << collision.gameObject.layer) & groundLayerMask) != 0 && collision.gameObject.GetComponent<PlayerMovementControl>().negativeGravity == isVoidGate)
            {
                playerObject = collision.gameObject;
                playerObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX;
                playerObject.GetComponent<PlayerMovementControl>().enabled = false;
                playerObject.GetComponent<PlayerAttacks>().enabled = false;
                playerObject.GetComponent<PlayerStatistics>().enabled = false;
                playerObject.GetComponent<Animator>().SetBool("IsRunningToGoal", true);



                this.transform.parent.GetComponent<GameManagement>().goalReachedCount++;

                collided = true;

                arrivedTime = Time.time;
                
            }
        }
    }
}
