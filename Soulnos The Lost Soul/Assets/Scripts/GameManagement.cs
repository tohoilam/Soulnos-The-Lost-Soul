using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagement : MonoBehaviour
{
    public GameObject deathScreen;
    public GameObject clearedText;
    public float textDelayTime;
    public int goalReachedCount;
    public int goalRequired;

    private bool isPlayerDeath;
    private float deathScreenDelayTime;
    private float deathTime;
    private bool deathScreenShowed;

    private float clearedTime;
    private bool isCleared;
    private bool textInstantiated;

    // Start is called before the first frame update
    void Start()
    {
        isPlayerDeath = false;
        deathScreenDelayTime = 1.0f;
        deathScreenShowed = false;

        isCleared = false;
        textInstantiated = false;
        goalReachedCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!deathScreenShowed && isPlayerDeath && Time.time > deathTime + deathScreenDelayTime)
        {
            Instantiate(deathScreen);
            Time.timeScale = 0;
            deathScreenShowed = true;
        }

        if (isCleared)
        {
            if (!textInstantiated && Time.time >= clearedTime + textDelayTime)
            {
                Instantiate(clearedText);
                textInstantiated = true;
                Time.timeScale = 0;
            }
        }

        if (!isCleared && goalReachedCount == goalRequired)
        {
            isCleared = true;
            clearedTime = Time.time;
        }
    }

    public void PlayerDied()
    {
        isPlayerDeath = true;
        deathTime = Time.time;
    }
}
