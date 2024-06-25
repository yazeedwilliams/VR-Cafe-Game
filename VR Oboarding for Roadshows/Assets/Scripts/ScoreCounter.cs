using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private int score = 0;
    [SerializeField] private TextMeshProUGUI scoreText;

    private void Start()
    {
        UpdatedScoreText();
    }

    public void AddScore(int points)
    {
        score += points;
        UpdatedScoreText();
    }

    void UpdatedScoreText()
    {
        scoreText.text = $"Score: {score}";
    }

    public int GetScore()
    {
        return score;
    }
}
