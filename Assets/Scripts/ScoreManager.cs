using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    public int scoreValue = 0;
    public int highScoreValue = 0;
    public TextMeshProUGUI Score;
    public TextMeshProUGUI HighScore;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        // Load the high score from PlayerPrefs
        highScoreValue = PlayerPrefs.GetInt("HighScore", 0);
        UpdateHighScoreText();
    }

    public void IncreaseScore()
    {
        scoreValue += 1;
        Score.text = "Score: " + scoreValue.ToString();

        
        if (scoreValue > highScoreValue)
        {
            highScoreValue = scoreValue;

           
            PlayerPrefs.SetInt("HighScore", highScoreValue);
            PlayerPrefs.Save();

            UpdateHighScoreText();
        }
    }

    private void UpdateHighScoreText()
    {
        HighScore.text = "High Score: " + highScoreValue.ToString();
    }
}
