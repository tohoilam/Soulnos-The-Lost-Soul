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
            SceneManager.LoadScene(3);
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
            SceneManager.LoadScene(4);
        }
        else
        {
            loadMenuUI.SetActive(false);
            notClearedText.SetActive(true);
        }
    }
    public void loadStage4()
    {
        if (stageCleared >= 4)
        {
            SceneManager.LoadScene(6);
        }
        else
        {
            loadMenuUI.SetActive(false);
            notClearedText.SetActive(true);
        }
    }
    public void loadStage5()
    {
        if (stageCleared >= 5)
        {
            SceneManager.LoadScene(7);
        }
        else
        {
            loadMenuUI.SetActive(false);
            notClearedText.SetActive(true);
        }
    }
    public void loadStage6()
    {
        if (stageCleared >= 6)
        {
            SceneManager.LoadScene(9);
        }
        else
        {
            loadMenuUI.SetActive(false);
            notClearedText.SetActive(true);
        }
    }
    public void loadStage7()
    {
        if (stageCleared >= 7)
        {
            SceneManager.LoadScene(10);
        }
        else
        {
            loadMenuUI.SetActive(false);
            notClearedText.SetActive(true);
        }
    }
    public void loadStage8()
    {
        if (stageCleared >= 8)
        {
            SceneManager.LoadScene(12);
        }
        else
        {
            loadMenuUI.SetActive(false);
            notClearedText.SetActive(true);
        }
    }
    public void loadStage9()
    {
        if (stageCleared >= 9)
        {
            SceneManager.LoadScene(13);
        }
        else
        {
            loadMenuUI.SetActive(false);
            notClearedText.SetActive(true);
        }
    }
    public void loadStageEND()
    {
        if (stageCleared >= 10)
        {
            SceneManager.LoadScene(15);
        }
        else
        {
            loadMenuUI.SetActive(false);
            notClearedText.SetActive(true);
        }
    }
}
