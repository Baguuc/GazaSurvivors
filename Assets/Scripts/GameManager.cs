using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum PlayerSide
{
    Israel,
    Palestine
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public PlayerSide playerSide;

    public void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        else if (Instance == null)
            Instance = this;

        DontDestroyOnLoad(gameObject);
    }
        
    public void NewGame()
    {
        SceneManager.LoadScene("CharacterSelectionScene");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void StartAs(PlayerSide asSide)
    {
        this.playerSide = asSide;
        SceneManager.LoadScene("GameScene");
    }
}
