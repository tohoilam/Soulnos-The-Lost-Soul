using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameCleared : MonoBehaviour
{
    public void nextStage()
    {
        int currentStage = SceneManager.GetActiveScene().buildIndex;
        if (currentStage < MainMenu.stageCleared) 
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            Time.timeScale = 1;
        }
        else
        {
            MainMenu.stageCleared += 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            Time.timeScale = 1;
        }
    }
    
}
