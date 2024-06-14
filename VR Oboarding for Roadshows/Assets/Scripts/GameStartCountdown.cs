using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameStartCountdown : MonoBehaviour
{
    [SerializeField] private float countdownTime = 5f; // Set the countdown time in seconds
    [SerializeField] private TextMeshProUGUI countdownText; // Reference to the UI Text element

    private float currentTime;

    private AudioSource gameStartSound;

    void Start()
    {
        currentTime = countdownTime;
        UpdateCountdownText();
        StartCoroutine(StartCountdown());
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

        // Trigger the start of the game
        gameStartSound = GetComponent<AudioSource>();
        gameStartSound.Play();
        gameObject.SetActive(false);
        StartGame();
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
