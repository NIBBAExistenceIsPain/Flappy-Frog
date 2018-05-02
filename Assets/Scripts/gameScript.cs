using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameScript : MonoBehaviour {

	bool gamePause = false;
	public GameObject player1;
	public GameObject player2;
	public GameObject screen;
	public GameObject menu;
    public GameObject pause;

	// Use this for initialization
	void Start () {
		screen.SetActive(false);
        pause.SetActive(false);
	}
	
	public void Begin()
	{
		Time.timeScale = 1;
		menu.SetActive(false);
        player1.name = menu.transform.GetChild(3).GetChild(1).GetComponent<Text>().text;
        player2.name = menu.transform.GetChild(4).GetChild(1).GetComponent<Text>().text;
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown("p"))
        {
            Debug.Log("Pressed");
			if(gamePause)
			{
				Time.timeScale = 1;
				menu.SetActive(false);
			}
			else
			{
				Time.timeScale = 0;
				menu.SetActive(true);
			}
			
			gamePause = !gamePause;
		}
	}
	
	public void Victory(int player)
	{
		Time.timeScale = 0;
		screen.SetActive(true);
        if (player == 1)
            screen.transform.GetChild(3).GetComponent<Text>().text = player2.name;
        else
            screen.transform.GetChild(3).GetComponent<Text>().text = player1.name;
	}

    public void Replay()
    {
        Application.LoadLevel(0);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
