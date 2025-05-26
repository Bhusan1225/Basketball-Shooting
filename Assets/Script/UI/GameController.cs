
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public enum Zone
    {
        None,
        Practice,
        Play,
        ArcadeChallange

    }

   
    [Header("Game Level")]
    [SerializeField] TextMeshProUGUI gameLevelText;


    public Zone currentZone = Zone.Practice;

    [Header("Timer")]
    [SerializeField] float timeRemaining ;
    [SerializeField] TextMeshProUGUI timmerText;
    [SerializeField] bool timerIsRunning = false;
     [SerializeField] GameObject gameOverPanel;
    [SerializeField] GameObject gameWinningPanel;

    [Header("Shooting Target")]
    [SerializeField] TextMeshProUGUI targetText;
    [SerializeField] int target = 5;
    [SerializeField] Scoring playerScore;
    [SerializeField] Slider targetSetting;

    [SerializeField] GameObject practiceZoneSettingUI;



    // void Start()
    //{
    //    if (currentZone == Zone.Practice)
    //    {
    //        timerIsRunning = true;
    //        UpdateTargetDisplay();
    //        Debug.Log("This is a practice zone");

    //    }
    //    else if (currentZone == Zone.Play)
    //    {
    //        timerIsRunning = true;
    //        timmerText.text = "Timer: " + (int)timeRemaining;
    //        target = Random.Range(5, target);
    //        targetText.text = "Target:" + target;
    //        GameDifficultyLevel();
    //        Debug.Log("This is a play zone");
    //    }
    //}

    private void Start()
    {
        if (currentZone == Zone.Practice)
        {
           timerIsRunning = true;
           UpdateTargetDisplay();
           Debug.Log("This is a practice zone");

               }
               else if (currentZone == Zone.Play)
        {
            timerIsRunning = true;
            timmerText.text = "Timer: " + (int)timeRemaining;
            target = Random.Range(5, target);
            targetText.text = "Target:" + target;
            GameDifficultyLevel();
            Debug.Log("This is a play zone");
        }

    }

    private void GameDifficultyLevel()
    {
        if (target >= 5 && target <= 8)
        {
            gameLevelText.text = "Level: Easy";
        }
        else if (target > 8 && target <= 12)
        {
            gameLevelText.text = "Level: Medium";
        }
        else if (target > 12)
        {
            gameLevelText.text = "Level: Hard";
        }
    }

    void UpdateTimerDisplay()
    {
        timmerText.text = "Timer: " + (int)timeRemaining;
    }
   
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            OpenPracticeZoneSetting();
            
        }

        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                Debug.Log("This is a play zone");
                UpdateTimerDisplay();

            }
            else
            {
                if (playerScore.GetScore() >= target)
                {
                    gameWinningPanel.SetActive(true);
                    timerIsRunning = false;
                    Time.timeScale = 0f;
                }
                else if (playerScore.GetScore() < target) // or just use `else`
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




    public void OpenPracticeZoneSetting()
    {
        practiceZoneSettingUI.SetActive(true);
        Time.timeScale = 0f;
        target = (int)targetSetting.value;
        targetSetting.onValueChanged.AddListener(UpdateTarget);
        
    }

    private void UpdateTarget(float newTarget)
    {
        target = (int)newTarget;
        UpdateTargetDisplay();
    }

    void UpdateTargetDisplay()
    {
        targetText.text = "Target: " + target;
    }

    public void ClosePracticeZoneSetting()
    {
        practiceZoneSettingUI.SetActive(false);
        Time.timeScale = 1f;
    }

    public void SetTimerBool()
    {
        timerIsRunning = true;
    }

}
