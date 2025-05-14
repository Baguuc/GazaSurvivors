using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void Start()
    {
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
}
