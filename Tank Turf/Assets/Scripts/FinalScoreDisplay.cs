using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinalScoreDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text finalScoreText;

    private void Start(){
        if (ScoreManager.Instance != null){
            finalScoreText.text = "Final Score: " + ScoreManager.Instance.GetScore();
        }
        else{
            finalScoreText.text = "Final Score: 0";
        }
    }
}
