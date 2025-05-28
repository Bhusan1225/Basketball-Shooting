using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoringUI : MonoBehaviour
{

    /// <summary>
    /// This  scripts handles the score system of the game 
    /// </summary>
    [SerializeField] int score;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] int increament = 1; // you a set the point increment in each shoot

    private void Start()
    {
        score = 0;
        scoreText.text = "Socre: " + score;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            Debug.Log("you scored 1 point.");
            AddPoints(increament);
        }
    }

    public void AddPoints(int points)
    {
        //Increase the point when the player shoots net
        score += points;
        scoreText.text = "Socre: " + score;
    }

    public int GetScore()
    {
        return score;
    }

    public void SetScore(int point)
    {
          score = point;
    }
}
