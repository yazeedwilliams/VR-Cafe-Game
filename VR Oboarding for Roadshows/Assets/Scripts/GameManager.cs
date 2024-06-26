using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI gameTimerText;
    [SerializeField] private UnityEvent onGameEnd;

    private ScoreCounter scoreCount;

    private float startTime = 5f;
    private float currentTime;

    private void Start()
    {
        scoreCount = FindAnyObjectByType<ScoreCounter>();
    }

    public void StartGame()
    {
        ResetTimer();
        StartCoroutine(GameTimeCountdown());
    }

    private void ResetTimer()
    {
        currentTime = startTime;
        gameTimerText.text = Mathf.Ceil(currentTime).ToString();
    }

    private IEnumerator GameTimeCountdown()
    {
        while (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            gameTimerText.text = Mathf.Ceil(currentTime).ToString();
            yield return null;
        }
        TimerEnded();
        yield return new WaitForSeconds(1f);
    }

    private void TimerEnded()
    {
        gameTimerText.text = "Game Over!";
        onGameEnd.Invoke();
    }

    private void GameOver()
    {
        if (scoreCount.GetScore() == 2)
        {
            onGameEnd.Invoke();
        }
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game");
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
