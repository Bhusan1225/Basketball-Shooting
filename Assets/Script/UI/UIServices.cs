using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIServices : MonoBehaviour
{
    [Header("Game Level UI")]
    [SerializeField] TextMeshProUGUI gameLevelText;

    // Current selected game mode
    public GameMode currentMode = GameMode.Practice;

    [Header("Timer Settings")]
    [SerializeField] float timeRemaining = 60f; // Initial time limit
    [SerializeField] TextMeshProUGUI timmerText; // Timer UI text
    [SerializeField] bool timerIsRunning = false; // Controls timer flow
    [SerializeField] GameObject gameOverPanel; // Shown when time is up and target not met
    [SerializeField] GameObject gameWinningPanel; // Shown when target is achieved in time

    [Header("Add Target Settings")]
    [SerializeField] TextMeshProUGUI targetText; // Target UI display
    [SerializeField] int target = 5; // Default target value
    [SerializeField] ScoringUI playerScore; // Reference to player score script
    [SerializeField] Slider targetSetting; // Slider to adjust target in practice mode

    [SerializeField] GameObject practiceModeSettingUI; // UI for practice mode settings

    [Header("Other Settings")]
    [SerializeField] GameObject moreSettingPanel; // UI for pause/settings in Play/Arcade

 
    



    private void Start()
    {
        Time.timeScale = 1f;

        // Configure settings based on game mode
        if (currentMode == GameMode.Practice)
        {
            timerIsRunning = true;
            UpdateTargetDisplay();
            Debug.Log("This is a practice mode");
        }
        else if (currentMode == GameMode.ArcadeChallange || currentMode == GameMode.Play)
        {
            timerIsRunning = true;
            timmerText.text = "Timer: " + (int)timeRemaining;

            // Randomize target for added challenge
            target = Random.Range(5, target);
            targetText.text = "Target: " + target;

            // Display difficulty level
            GameDifficultyLevel();

            Debug.Log("This is a play mode");
        }
      


    }

   

    // Set game level difficulty text based on target value
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

    void Update()
    {
        // Timer countdown
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                UpdateTimerDisplay();
            }
            else
            {
                // Time's up - check win/loss
                timeRemaining = 0;
                timerIsRunning = false;

                if (playerScore.GetScore() >= target)
                {
                    gameWinningPanel.SetActive(true);
                }
                else
                {
                    Debug.Log("Time's up!");
                    gameOverPanel.SetActive(true);
                }

                Time.timeScale = 0f;
            }
        }
    }

    public void ModeSettingUI()
    {   
        // change mode setting as per the GameMode
        if (currentMode == GameMode.Practice)
        {
            OpenPracticeModeSetting();
        }
        else if (currentMode == GameMode.ArcadeChallange || currentMode == GameMode.Play)
        {
            OpenPlayModeSetting();
        }
    }
    // Show pause/settings panel for Play/Arcade mode
    private void OpenPlayModeSetting()
    {
        moreSettingPanel.SetActive(true);
    }

    // Show settings UI for Practice mode
    public void OpenPracticeModeSetting()
    {
        practiceModeSettingUI.SetActive(true);
        Time.timeScale = 0f;

        // Set slider to current target
        target = (int)targetSetting.value;

        // Add listener to update target when slider changes
        targetSetting.onValueChanged.AddListener(UpdateTarget);

        // Update UI with new target
        UpdateTargetDisplay();
    }

    // Update the target value when slider is changed
    private void UpdateTarget(float newTarget)
    {
        target = (int)newTarget;
        UpdateTargetDisplay();
    }

    // Display current target value in UI
    void UpdateTargetDisplay()
    {
        targetText.text = "Target: " + target;
    }

    // Update the timer display on screen
    void UpdateTimerDisplay()
    {
        timmerText.text = "Timer: " + (int)timeRemaining;
    }

    // Close the practice mode settings and resume game
    public void CloseModeSetting()
    {
        practiceModeSettingUI.SetActive(false);
        Time.timeScale = 1f;
    }


}
