using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum GameMode
{
    idle,
    playing,
    levelEnd
}

public class GameManager : MonoBehaviour
{
    [Header("Inscribed")]
    //public GameObject[] mazes;
    public Vector3 mazePos;
    public GameObject gameOverPanel;

    [Header("Dynamic")]
    //public int level;
    //public int levelMax;
    public int shotsTaken;
    public GameObject maze;
    public GameMode mode = GameMode.idle;

    // Start is called before the first frame update
    void Start()
    {
        //level = 0;
        shotsTaken = 0;
        //levelMax = mazes.Length;
        StartLevel();
    }

    void StartLevel()
    {
        if (maze != null)
        {
            Destroy(maze);
        }

        //maze = Instantiate<GameObject>(mazes[level]);
        //maze.transform.position = mazePos;

        PlayerTank.playerTankDestroyed = false;
        EnemyTank.enemyTankDestroyed = false;

        mode = GameMode.playing;
    }

    // Update is called once per frame
    void Update()
{
    if (mode != GameMode.playing) return;

    if (PlayerTank.playerTankDestroyed)
    {
        // Player death takes priority
        gameOverPanel.SetActive(true);
        //Time.timeScale = 0f;
        mode = GameMode.levelEnd; // Mark game as ended
        return; // Stop further checks
    }

    if (EnemyTank.enemyDone<=0)
    {
        // Only runs if player is still alives
        mode = GameMode.levelEnd;
        SceneManager.LoadSceneAsync(3);
    }
}

    public void GameOVerPanel()
    {
        SceneManager.LoadSceneAsync(0);
    }

    /*
    void NextLevel()
    {
        level++;
        if (level == levelMax)
        {
            //level = 0;
            //shotsTaken = 0;
        }
        StartLevel();
    }
    */
}
