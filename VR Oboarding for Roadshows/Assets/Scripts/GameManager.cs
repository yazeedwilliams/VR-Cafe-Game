using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public event EventHandler OnStateChanged;

    private enum State { 
        WaitingToStart,
        HandAndControllerTut,
        CountdownToStartGame, 
        GamePlaying, 
        GameOver
    }

    [SerializeField] private TextMeshProUGUI gameOverText;

    private State state;

    private float waitingToStartTimer = 1f;
    private float HandAndControllerTutTimer = 3f;
    private float countdownToStartGameTimer = 3f;
    private float gamePlayingTimer = 15f;

    private void Awake()
    {
        state = State.WaitingToStart;
    }

    private void Update()
    {
        switch (state)
        {
            case State.WaitingToStart:
                waitingToStartTimer -= Time.deltaTime;
                if (waitingToStartTimer < 0f)
                {
                    state = State.HandAndControllerTut;
                    OnStateChanged?.Invoke(this, EventArgs.Empty);
                }
                break;
            case State.HandAndControllerTut:
                HandAndControllerTutTimer -= Time.deltaTime;
                if (HandAndControllerTutTimer < 0f)
                {
                    state = State.CountdownToStartGame;
                    OnStateChanged?.Invoke(this, EventArgs.Empty);
                }
                break;
            case State.CountdownToStartGame:
                countdownToStartGameTimer -= Time.deltaTime;
                if (countdownToStartGameTimer < 0f)
                {
                    state = State.GamePlaying;
                    OnStateChanged?.Invoke(this, EventArgs.Empty);
                }
                break;
            case State.GamePlaying:
                gamePlayingTimer -= Time.deltaTime;
                if (gamePlayingTimer < 0f)
                {
                    state = State.GameOver;
                    OnStateChanged?.Invoke(this, EventArgs.Empty);
                }
                break;
            case State.GameOver:
                break;
        }
        Debug.Log(state);
    }

    public bool IsGamePlaying()
    {
        return state == State.GamePlaying;
    }

    public bool IsCountdownToStartActive()
    {
        return state == State.CountdownToStartGame;
    }

    public float GetCountdownToStartTimer()
    {
        return countdownToStartGameTimer;
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(false);
    }
}
