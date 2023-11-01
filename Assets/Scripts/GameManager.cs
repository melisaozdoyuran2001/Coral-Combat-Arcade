using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI; 
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float survivalTime = 90.0f; 
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI YouWonText; 

    public Button playAgain; 

    public Button startButton; 

    public TextMeshProUGUI WelcomeText; 

    void Start()
    {
    
        int hasGameStarted = PlayerPrefs.GetInt("HasGameStarted", 0);

        if (hasGameStarted == 0)
        {
            Time.timeScale = 0f;
            startButton.gameObject.SetActive(true);
            WelcomeText.gameObject.SetActive(true); 
        }
        else
        {
            if (startButton != null)
            {
                startButton.gameObject.SetActive(false);
                WelcomeText.gameObject.SetActive(false); 

            }
            Time.timeScale = 1f;
        }
        UpdateTimerText();
    }

    private void Update()
    {
        if (survivalTime > 0)
        {
            survivalTime -= Time.deltaTime;
            UpdateTimerText();
            
            if (survivalTime <= 0)
            {
                PlayerWins();
            }
        }
    }

    private void UpdateTimerText()
    {
        timerText.text = "Time: " + Mathf.Ceil(survivalTime).ToString();
    }

    private void PlayerWins()
    {
      
      playAgain.gameObject.SetActive(true); 
      YouWonText.gameObject.SetActive(true); 
      Time.timeScale = 0f;
    }

    public void StartGame()
    {
        PlayerPrefs.SetInt("HasGameStarted", 1);
        
        Time.timeScale = 1f;

       
        startButton.gameObject.SetActive(false);
        WelcomeText.gameObject.SetActive(false); 

        
    }

    public void LoadFirstScene()
    {
        
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

     private void OnApplicationQuit()
    {
        PlayerPrefs.DeleteKey("HasGameStarted");
    }
}

