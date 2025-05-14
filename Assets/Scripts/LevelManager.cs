using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManger : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI playerHealthText;
    public GameObject deathPanel;
    int points;
    int playerHealth;

    public void AddPoints(int n)
    {
        points += n;
    }

    public void ReducePlayerHeath(int n)
    {
        playerHealth -= n;

        if (playerHealth <= 0)
        {
            Time.timeScale = 0;
            deathPanel.SetActive(true);
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void Start()
    {
        points = 0;
        playerHealth = 10000;
    }

    private void Update()
    {
        scoreText.text = $"{points}";
        playerHealthText.text = $"{playerHealth}";
    }
}
