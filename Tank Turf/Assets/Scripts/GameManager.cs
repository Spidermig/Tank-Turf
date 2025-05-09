using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum GameMode
{
    idle,
    playing,
    levelEnd
}

public class GameManager : MonoBehaviour
{
    [Header("Inscribed")]
    public GameObject[] mazes;
    public Vector3 mazePos;

    [Header("Dynamic")]
    public int level;
    public int levelMax;
    public int shotsTaken;
    public GameObject maze;
    public GameMode mode = GameMode.idle;

    // Start is called before the first frame update
    void Start()
    {
        level = 0;
        shotsTaken = 0;
        levelMax = mazes.Length;
        StartLevel();
    }

    void StartLevel()
    {
        if (maze != null)
        {
            Destroy(maze);
        }

        maze = Instantiate<GameObject>(mazes[level]);
        maze.transform.position = mazePos;

        PlayerTank.playerTankDestroyed = false;
        EnemyTank.enemyTankDestroyed = false;

        mode = GameMode.playing;
    }

    // Update is called once per frame
    void Update()
    {
        if ((mode == GameMode.playing) && (PlayerTank.playerTankDestroyed || EnemyTank.enemyTankDestroyed))
        {
            mode = GameMode.levelEnd;
            Invoke("NextLevel", 2f);
        }
    }

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

    //
}
