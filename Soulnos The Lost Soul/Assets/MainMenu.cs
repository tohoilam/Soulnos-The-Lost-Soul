using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{   
    public static int stageCleared = 1;
    public GameObject loadMenuUI;
    public GameObject notClearedText;
    public void QuitGame()
    {
        Application.Quit();
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }
    public void loadStage1()
    {
        if (stageCleared >= 1)
        {
            SceneManager.LoadScene(1);
        }
        else
        {
            loadMenuUI.SetActive(false);
            notClearedText.SetActive(true);
        }
    }
    public void loadStage2()
    {
        if (stageCleared >= 2)
        {
            SceneManager.LoadScene(2);
        }
        else
        {
            loadMenuUI.SetActive(false);
            notClearedText.SetActive(true);
        }
    }
    public void loadStage3()
    {
        if (stageCleared >= 3)
        {
            SceneManager.LoadScene(3);
        }
        else
        {
            loadMenuUI.SetActive(false);
            notClearedText.SetActive(true);
        }
    }
}
