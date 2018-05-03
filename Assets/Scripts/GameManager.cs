using UnityEngine;
using System.Collections;

using System.Collections.Generic;      
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager instance = null;
    public static string player1;
    public static string player2;
    public static int trigger;

    void Awake()
    {
        if (instance == null)

            instance = this;

        else if (instance != this)

            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

    }

    void Update()
    {


    }

    public static void Play()
    {
        Debug.Log("playing");
        SceneManager.LoadScene(1);
    }

    public static void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public static void Victory()
    {
        SceneManager.LoadScene(2);
    }

    public static void Exit()
    {
        Debug.Log("Exiting");
        Application.Quit();
    }
}