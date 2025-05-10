using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreUIUpdater : MonoBehaviour{    
    [SerializeField] private TMP_Text scoreText;

    private void Awake(){
        if (scoreText == null){
            scoreText = GetComponent<TMP_Text>();  // Auto-find if not assigned
        }
    }
    
    private void Update(){
        scoreText.text = "Score: " + ScoreManager.Instance.GetScore();
    }
}
