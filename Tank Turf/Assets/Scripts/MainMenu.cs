using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        // Load the game scene (assuming it's named "GameScene")
        SceneManager.LoadSceneAsync(1);
    }

    public void QuitGame()
    {
        // Quit the application
        Application.Quit();
        Debug.Log("Game is quitting...");
    }
}
