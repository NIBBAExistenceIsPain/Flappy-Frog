using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VictoryScreen : MonoBehaviour {

	void Start () {
        if (GameManager.trigger == Player.one)
            transform.GetChild(1).GetComponent<Text>().text = GameManager.player2;
        else
            transform.GetChild(1).GetComponent<Text>().text = GameManager.player1;
    }

    public void Replay()
    {
        GameManager.Play();
    }

    public void Exit()
    {
        GameManager.Exit();
    }

    public void MainMenu()
    {
        GameManager.MainMenu();
    }
}
