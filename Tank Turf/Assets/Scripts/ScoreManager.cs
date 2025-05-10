using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public int bulletCount = 0;

    private void Awake(){
        if (Instance == null){
            Instance = this;
            DontDestroyOnLoad(gameObject); // Persist across scenes
        }
        else{
            Destroy(gameObject);
        }
    }

    public void AddBullet(){
        bulletCount++;
    }

    public void ResetScore(){
        bulletCount = 0;
    }

    public int GetScore(){
        return bulletCount;
    }
}
