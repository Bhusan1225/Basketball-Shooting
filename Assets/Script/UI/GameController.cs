using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] float timeRemaining ;
    [SerializeField] TextMeshProUGUI timmerText;
    [SerializeField] bool timerIsRunning = false;
    [SerializeField] GameObject gameOverPanel;



    void Start()
    {
        timerIsRunning = true;
        timmerText.text = "Timer: " + (int)timeRemaining;

    }

    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                timmerText.text = "Timer: " + (int)timeRemaining;
            }
            else
            {
                Debug.Log("Time's up!");
                timeRemaining = 0;
                timerIsRunning = false;
                gameOverPanel.SetActive(true);
                Time.timeScale = 0f;
            }
        }
    }
}
