using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private int startScore = 0;
    [SerializeField] private TextMeshProUGUI scoreText;

    private int score;

    private void Start()
    {
        ResetScore();
        UpdatedScoreText();
    }

    private void ResetScore()
    {
        score = startScore;
        scoreText.text = $"Score: {score}";
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
