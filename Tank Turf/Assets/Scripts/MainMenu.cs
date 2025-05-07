using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


// Goto file(top left corner) > build settings and then youll see all the screens and their acossiated numbers
public class MainMenu : MonoBehaviour
{
    public Button tank1;
    public Button tank2;
    public Button tank3;

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

    void Start()
    {
        tank1.onClick.AddListener(() => tankSelectionAndStartGame(0));
        tank2.onClick.AddListener(() => tankSelectionAndStartGame(1));
        tank3.onClick.AddListener(() => tankSelectionAndStartGame(2));
    }

    public void tankSelectionAndStartGame(int tankID)
    {
        GameData.selectedTankIndex = tankID;
        SceneManager.LoadSceneAsync(2);
    }
    
}
