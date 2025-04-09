using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelManger : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    int points;

    void Start()
    {
        points = 0;   
    }

    void Update()
    {
        scoreText.text = $"Wynik: {points}";
    }

    public void AddPoints(int n)
    {
        points += n;
    }
}
