using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameScript : MonoBehaviour {

	bool gamePause = false;
    public GameObject pause;
    public Entity pepe1;
    public Entity pepe2;

	// Use this for initialization
	void Start () {
        pepe1 = transform.GetChild(0).GetComponent<Entity>();
        pepe2 = transform.GetChild(1).GetComponent<Entity>();
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
                pepe1.enabled = true;
                pepe2.enabled = true;
                Time.timeScale = 1;
				pause.SetActive(false);
			}
			else
			{
                pepe1.enabled = false;
                pepe2.enabled = false;
				Time.timeScale = 0;
				pause.SetActive(true);
			}
			
			gamePause = !gamePause;
		}
	}
}
