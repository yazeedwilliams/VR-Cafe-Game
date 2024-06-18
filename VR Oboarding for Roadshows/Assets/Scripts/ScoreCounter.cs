using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private int score = 0;
    public TextMeshProUGUI scoreText;

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
}
