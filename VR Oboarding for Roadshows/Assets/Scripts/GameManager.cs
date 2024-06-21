using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
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
                }
                break;
            case State.HandAndControllerTut:
                HandAndControllerTutTimer -= Time.deltaTime;
                if (HandAndControllerTutTimer < 0f)
                {
                    state = State.CountdownToStartGame;
                }
                break;
            case State.CountdownToStartGame:
                countdownToStartGameTimer -= Time.deltaTime;
                if (countdownToStartGameTimer < 0f)
                {
                    state = State.GamePlaying;
                }
                break;
            case State.GamePlaying:
                gamePlayingTimer -= Time.deltaTime;
                if (gamePlayingTimer < 0f)
                {
                    state = State.GameOver;
                }
                break;
            case State.GameOver:
                break;
        }
        Debug.Log(state);
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(false);
    }
}
