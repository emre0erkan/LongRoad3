using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);        //starting the game scene when clicking play button
    }

    public void QuitGame()
    {
        Debug.Log("QUIT!");         //closing the game
        Application.Quit();
    }

}
