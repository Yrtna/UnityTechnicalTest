using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public int CurrentScore => currentScore;

    private int currentScore = 0;

    [SerializeField]
    private Text scoreText;

    public void UpdateScore()
    {
        scoreText.text = ScoreString();
    }

    public string ScoreString()
    {
        return $"Score: {CurrentScore}";
    }
    
    public void AddScore(int qty)
    {
        currentScore += qty;
        UpdateScore();
    }
}
