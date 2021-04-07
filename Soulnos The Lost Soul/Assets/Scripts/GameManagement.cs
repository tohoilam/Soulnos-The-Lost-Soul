using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagement : MonoBehaviour
{
    public GameObject deathScreen;

    private bool isPlayerDeath;
    private float deathScreenDelayTime;
    private float deathTime;
    private bool deathScreenShowed;

    // Start is called before the first frame update
    void Start()
    {
        isPlayerDeath = false;
        deathScreenDelayTime = 1.0f;
        deathScreenShowed = false;
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
    }

    public void PlayerDied()
    {
        isPlayerDeath = true;
        deathTime = Time.time;
    }
}
