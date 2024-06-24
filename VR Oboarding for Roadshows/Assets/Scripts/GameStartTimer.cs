using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class GameStartTimer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI gameStartTimerText;
    [SerializeField] private float startTime = 3f;
    [SerializeField] private UnityEvent onGameStart;

    private float currentTime;

    private void OnEnable()
    {
        ResetTimer();
        StartCoroutine(Countdown());
    }

    private void ResetTimer()
    {
        currentTime = startTime;
        gameStartTimerText.text = Mathf.Ceil(currentTime).ToString();
    }

    private IEnumerator Countdown()
    {
        while (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            gameStartTimerText.text = Mathf.Ceil(currentTime).ToString();
            yield return null;
        }
        TimerEnded();
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);
    }

    private void TimerEnded()
    { 
        gameStartTimerText.text = "Go!";
        onGameStart.Invoke();
    }
}
