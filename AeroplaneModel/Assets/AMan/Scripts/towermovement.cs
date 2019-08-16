using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class towermovement : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		Destroy (this.gameObject, 4);
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(-0.2f, 0, 0, Space.World);

		
	}
}
