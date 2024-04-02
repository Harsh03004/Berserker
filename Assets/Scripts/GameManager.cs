using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void playGame()
    {
        Debug.Log("Loading the game");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Quitgame()
    {
        Debug.Log("Quitting the game");
        Application.Quit();
    }

    public void playAgain()
    {
        Debug.Log("Restarting the game");
        SceneManager.LoadScene(1);
    }
}
