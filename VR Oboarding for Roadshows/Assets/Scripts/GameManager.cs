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
    [SerializeField] private AudioSource audioSource;

    [SerializeField] private AudioClip introAudio;
    [SerializeField] private AudioClip rayAudio;
    [SerializeField] private AudioClip selectAndMoveAudio;
    [SerializeField] private AudioClip grabAudio;

    private ScoreCounter scoreCount;

    private float timeDelay = 13f;
    private float startTime = 45f;
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
            if (scoreCount.GetScore() == 3)
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

    private void PlayIntroAudio()
    {
        audioSource.clip = introAudio;
        audioSource.Play();
    }

    private void PlayRayAudio()
    {
        audioSource.clip = rayAudio;
        audioSource.Play();
    }

    private void PlaySelectAndMoveAudio()
    {
        audioSource.clip = selectAndMoveAudio;
        audioSource.Play();
    }

    public void PlayGrabAudio()
    {
        audioSource.clip = grabAudio;
        audioSource.Play();
    }

    private IEnumerator Deactivate()
    {
        PlayIntroAudio();
        yield return new WaitForSeconds(timeDelay);
        introBackground.SetActive(false);
        rayBackground.SetActive(true);
        PlayRayAudio();
        yield return new WaitForSeconds(timeDelay);
        rayBackground.SetActive(false);
        selectAndMoveBackground.SetActive(true);
        PlaySelectAndMoveAudio();
    }
}
