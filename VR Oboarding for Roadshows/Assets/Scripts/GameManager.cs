using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI gameOverText;

    private void Start()
    {
        gameOverText.gameObject.SetActive(false);
    }
}
