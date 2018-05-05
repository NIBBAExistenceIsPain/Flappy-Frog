using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

	void Start () {
        GameManager.trigger = 0;
	}

    public void ChangePlayerOne()
    {
        GameManager.player1 = gameObject.transform.GetChild(3).GetChild(1).GetComponent<Text>().text;
    }

    public void ChangePlayerTwo()
    {
        GameManager.player2 = gameObject.transform.GetChild(4).GetChild(1).GetComponent<Text>().text;
    }

    public void StartGame()
    {
        GameManager.Play();
    }

    public void Exit()
    {
        GameManager.Exit();
    }
}
