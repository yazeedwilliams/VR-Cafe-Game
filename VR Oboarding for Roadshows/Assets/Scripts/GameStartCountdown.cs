using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameStartCountdown : MonoBehaviour
{
    [SerializeField] private float countdownTime = 5f; // Set the countdown time in seconds
    [SerializeField] private TextMeshProUGUI countdownText; // Reference to the UI Text element
    [SerializeField] private AudioSource gameStartSound;

    private float currentTime;
    private bool isCountdownStarted;

    void Start()
    {
        enabled = false;
    }

    public void StartCountDown()
    {
        if (!enabled)
        {
            enabled = true;
            currentTime = countdownTime;
            UpdateCountdownText();
            StartCoroutine(StartCountdown());
        }
    }

    // Coroutine to handle the countdown
    IEnumerator StartCountdown()
    {
        while (currentTime > 0)
        {
            yield return new WaitForSeconds(1f);
            currentTime--;
            UpdateCountdownText();
        }

        if (gameStartSound != null)
            gameStartSound.Play();

        // Trigger the start of the game
        StartGame();
        gameObject.SetActive(false);
    }

    // Method to update the countdown text UI
    void UpdateCountdownText()
    {
        countdownText.text = "Starting in: " + currentTime.ToString("0");
    }

    // Method to start the game
    void StartGame()
    {
        countdownText.text = "Go!";
        // Add logic to start your game here
        // For example, you might enable player controls, start spawning enemies, etc.
        // Or load a new scene: SceneManager.LoadScene("GameScene");
    }
}
