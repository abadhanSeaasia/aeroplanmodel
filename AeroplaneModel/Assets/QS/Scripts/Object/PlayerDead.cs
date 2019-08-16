using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerDead : MonoBehaviour {

	private Manager manager;

	// Use this for initialization
	void Start () {
		manager = GameObject.Find ("Scripts").GetComponent<Manager> ();
		manager.SoundDead1 ();
		manager.SoundDead3 ();

		GetComponent<Rigidbody2D>().AddForce (new Vector2 (80, 80));
	}
}
