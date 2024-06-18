using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI gameOverText;

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }
}
