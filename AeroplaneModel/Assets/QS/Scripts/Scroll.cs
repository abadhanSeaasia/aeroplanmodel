using UnityEngine;
using System.Collections;

/*
Manages the status of background images
*/
public class Scroll : MonoBehaviour {
	public float speed;
	public int distance = 8;

	GameObject player;
	Player playerCode;
	Manager manager;
	
	void Start () {
		manager = GameObject.Find ("Scripts").GetComponent<Manager> ();
	}
	
	void Update () {
		if (manager.startGame && !manager.deadPlayer) {
			player = GameObject.FindGameObjectWithTag("Player");

			if (player != null) {
				playerCode = player.GetComponent<Player>();
				if (playerCode != null) {
					float dist = playerCode.pos * (speed * manager.powerUpFlash);
					if (playerCode.pos < 0f)
						dist += (float)distance;
					dist -= ((int)dist / distance) * distance;
	
					Vector3 pos = transform.position;
					transform.position = new Vector3 ((dist * -1), pos.y, pos.z);
				}
			}
		}
	}
}