using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreBoard : MonoBehaviour
{
    int score;

    TMP_Text scoreText;

    void Start() {
        scoreText = GetComponent<TMP_Text>();
        scoreText.text = "Start";
    }
    // The Method is to increase the score when
    // killing an enemy
    public void IncreaseScore(int amountToIncrease)
    {
        score += amountToIncrease;
        scoreText.text = "Score : " +score.ToString();
        // Debug.Log("The score is : " + score);

    }
}
