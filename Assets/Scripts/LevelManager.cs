using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelManger : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI playerHealthText;
    int points;
    int playerHealth;

    void Start()
    {
        points = 0;
        playerHealth = 100;
    }

    void Update()
    {
        scoreText.text = $"Wynik: {points}";
        playerHealthText.text = $"Zdrowie: {playerHealth}";
    }

    public void AddPoints(int n)
    {
        points += n;
    }

    public void ReducePlayerHeath(int n)
    {
        playerHealth -= n;
    }
}
