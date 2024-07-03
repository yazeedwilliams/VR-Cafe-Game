using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject introBackground;
    [SerializeField] private GameObject rayBackground;
    [SerializeField] private GameObject selectAndMoveBackground;
    [SerializeField] private TextMeshProUGUI gameTimerText;
    [SerializeField] private UnityEvent onGameEnd;

    private ScoreCounter scoreCount;

    private float timeDelay = 4f;
    private float startTime = 20f;
    private float currentTime;

    private void Start()
    {
        scoreCount = FindAnyObjectByType<ScoreCounter>();
        StartCoroutine(Deactivate());
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
            if (scoreCount.GetScore() == 2)
            {
                GameOver();
            }
            yield return null;
        }
        GameOver();
        yield return new WaitForSeconds(1f);
    }

    private void GameOver()
    {
        gameTimerText.text = "Game Over!";
        onGameEnd.Invoke();
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game");
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    private IEnumerator Deactivate()
    {
        yield return new WaitForSeconds(timeDelay);
        introBackground.SetActive(false);
        rayBackground.SetActive(true);
        yield return new WaitForSeconds(timeDelay);
        rayBackground.SetActive(false);
        selectAndMoveBackground.SetActive(true);
    }
}
