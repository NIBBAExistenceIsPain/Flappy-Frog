using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameScript : MonoBehaviour {

	bool gamePause = false;
    public GameObject pause;

	// Use this for initialization
	void Start () {
        pause.SetActive(false);
        Time.timeScale = 1;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown("p"))
        {
            Debug.Log("Pressed");
			if(gamePause)
			{
				Time.timeScale = 1;
				pause.SetActive(false);
			}
			else
			{
				Time.timeScale = 0;
				pause.SetActive(true);
			}
			
			gamePause = !gamePause;
		}
	}
}
