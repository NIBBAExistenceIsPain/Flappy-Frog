using UnityEngine;
using System.Collections;

using System.Collections.Generic;      
using UnityEngine.SceneManagement;

public enum Player
{
    one,
    two
}

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public static string player1;
    public static string player2;
    public static Player trigger;

    void Awake()
    {
        if (instance == null)

            instance = this;

        else if (instance != this)

            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        MainMenu();
    }

    public static void Play()
    {
        SceneManager.LoadScene(1);
    }

    public static void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public static void Victory(Player dead)
    {
        trigger = dead;
        SceneManager.LoadScene(2);
    }

    public static void Exit()
    {
        Debug.Log("Exiting");
        Application.Quit();
    }
}