using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject HowMenu;

    public void playgame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void quitgame()
    {
        Application.Quit();
        
    }

    public void Remenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void openHow()
    {
        HowMenu.SetActive(true);
    }

    public void closeHow()
    {
        HowMenu.SetActive(false);
    }

}
