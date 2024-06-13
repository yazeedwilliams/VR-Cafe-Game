using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateScore : MonoBehaviour
{
    private ScoreCounter scoreCounter;

    private void Start()
    {
        scoreCounter = GetComponent<ScoreCounter>();
    }

    public void IncreasScore(int points)
    {
        if (scoreCounter != null)
            scoreCounter.AddScore(points);
    }
}
