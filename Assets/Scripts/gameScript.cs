using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameScript : MonoBehaviour {

	bool gamePause = false;
	public GameObject player1;
	public GameObject player2;
	public GameObject menu;

	// Use this for initialization
	void Start () {
		
	}
	
	public void Begin()
	{
		Time.timeScale = 1;
		menu.SetActive(false);
		
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
}
