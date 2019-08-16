using UnityEngine;
using System.Collections;

public class StartGame : MonoBehaviour {
	
	private Manager manager;

	// Use this for initialization
	void Start () {
		manager = GameObject.Find ("Scripts").GetComponent<Manager> ();	
	}
	
	void OnMouseDownMobile() {
		manager.startGame = true;
		if (Time.timeScale < 1)
			Time.timeScale = 1;
	}
}
