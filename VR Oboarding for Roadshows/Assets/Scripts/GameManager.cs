using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI gameTimerText;
    [SerializeField] private UnityEvent onGameEnd;
    [SerializeField] private AudioSource audioSource;

    [SerializeField] private AudioClip successfulAudio;
    [SerializeField] private AudioClip unsuccessfulAudio;

    private ScoreCounter scoreCount;

    private float startTime = 45f;
    private float currentTime;

    private void Start()
    {
        scoreCount = FindAnyObjectByType<ScoreCounter>();
        //StartCoroutine(Deactivate());
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
            if (scoreCount.GetScore() == 3)
            {
                PlaySuccessfulAudio();
                GameOver();
                //StopCoroutine(GameTimeCountdown());
            }
            yield return null;
        }
        PlayUnsuccessfulAudio();
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

    private void PlaySuccessfulAudio()
    {
        audioSource.clip = successfulAudio;
        audioSource.Play();
    }

    private void PlayUnsuccessfulAudio()
    {
        audioSource.clip = unsuccessfulAudio;
        audioSource.Play();
    }
}
