using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyStatus : MonoBehaviour
{
    public enum Status
    {
        JumpHeightBoost,
        JumpHeightReduce,
        SpeedBoost,
        SpeedReduce,
    }

    public float boostDuration;
    public Status statusToApply;
    public float respawnTime;
    [SerializeField] public LayerMask playerLayer;

    public float jumpHeightBoostNewValue;
    public float jumpHeightReduceNewValue;
    public float speedBoost;
    public float speedReduce;

    private float appliedTime;
    private bool effectApplied;
    private float floatResetValue;
    private GameObject appliedObject;
    private bool isDisable;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (effectApplied && Time.time > appliedTime + boostDuration)
        {
            removeEffect();
        }

        if (isDisable && Time.time > appliedTime + respawnTime)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            gameObject.GetComponent<CircleCollider2D>().enabled = true;

            isDisable = false;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!effectApplied && collision.gameObject.layer == (int)Mathf.Log(playerLayer.value, 2))
        {
            appliedObject = collision.gameObject;
            switch (statusToApply)
            {
                
                case Status.JumpHeightBoost:
                    floatResetValue = appliedObject.GetComponent<PlayerMovementControl>().jumpForce;
                    appliedObject.GetComponent<PlayerMovementControl>().jumpForce = jumpHeightBoostNewValue;
                    break;
                case Status.JumpHeightReduce:
                    floatResetValue = appliedObject.GetComponent<PlayerMovementControl>().jumpForce;
                    appliedObject.GetComponent<PlayerMovementControl>().jumpForce = jumpHeightReduceNewValue;
                    break;
                case Status.SpeedBoost:
                    floatResetValue = appliedObject.GetComponent<PlayerMovementControl>().speed;
                    appliedObject.GetComponent<PlayerMovementControl>().speed = speedBoost;
                    break;
                case Status.SpeedReduce:
                    floatResetValue = appliedObject.GetComponent<PlayerMovementControl>().speed;
                    appliedObject.GetComponent<PlayerMovementControl>().speed = speedReduce;
                    break;
            }
            effectApplied = true;
            isDisable = true;
            appliedTime = Time.time;
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<CircleCollider2D>().enabled = false;

        }
    }

    private void removeEffect()
    {
        switch (statusToApply)
        {
            case Status.JumpHeightBoost:
            case Status.JumpHeightReduce:
                appliedObject.GetComponent<PlayerMovementControl>().jumpForce = floatResetValue;
                break;
            case Status.SpeedBoost:
            case Status.SpeedReduce:
                appliedObject.GetComponent<PlayerMovementControl>().speed = floatResetValue;
                break;

        }
        effectApplied = false;

        //Destroy(gameObject);
    }
}
