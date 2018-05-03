using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VictoryScreen : MonoBehaviour {

	void Start () {
        if (GameManager.trigger == 1)
            gameObject.transform.GetChild(3).GetComponent<Text>().text = GameManager.player2;
        else
            gameObject.transform.GetChild(3).GetComponent<Text>().text = GameManager.player1;
    }
	
	void Update () {
		
	}

    public void Replay()
    {
        GameManager.Play();
    }

    public void Exit()
    {
        GameManager.Exit();
    }
}
