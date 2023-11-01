using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro; 

public class LoseLineController : MonoBehaviour
{
    public Button playAgain; 
    public TextMeshProUGUI youLost; 
    private void OnTriggerEnter2D(Collider2D other) {
    if (other.gameObject.CompareTag("enemy")) {
        playAgain.gameObject.SetActive(true); 
        youLost.gameObject.SetActive(true); 
        Time.timeScale = 0f;
    }
}

   public void LoadScene() {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }


}