using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Scoring : MonoBehaviour
{
    [SerializeField] int score;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] int increament = 1;

    private void Start()
    {
        score = 0;
        scoreText.text = "Socre: " + score;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            Debug.Log("you scored 1 point.");
            AddPoints(increament);
        }
    }

    public void AddPoints(int points)
    {
        score += points;
        scoreText.text = "Socre: " + score;
    }

    public void ReducePoints(int points)
    {
        score -= points;
        scoreText.text = "Socre: " + score;
    }



}
