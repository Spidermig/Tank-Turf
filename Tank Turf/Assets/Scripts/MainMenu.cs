using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


// Goto file(top left corner) > build settings and then youll see all the screens and their acossiated numbers
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

    public void endScreen()
    {
        // Load the home scene 
        SceneManager.LoadSceneAsync(0);
    }

    public void actualGameScene()
    {
        //I think this is where we add what tank to load on the game screen


        // Load the game scene
        SceneManager.LoadSceneAsync(2);
    }
    
}
