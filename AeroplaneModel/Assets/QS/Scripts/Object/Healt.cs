using UnityEngine;
using System.Collections;

public class Healt : MonoBehaviour {

	public Vector2 velocity = new Vector2(-4f, 0);
	private Manager manager;

	// Use this for initialization
	void Start () {
		manager = GameObject.Find ("Scripts").GetComponent<Manager> ();
	}
	
	// Update is called once per frame
	void Update()
	{
		if (manager.startGame && manager.deadPlayer) {
			GetComponent<Rigidbody2D>().velocity = Vector2.zero;
		}
	}

	void FixedUpdate()
	{
		if (manager.startGame && !manager.deadPlayer) {
			Vector2 newVelocity = new Vector2((velocity.x * manager.powerUpFlash), velocity.y);
			GetComponent<Rigidbody2D>().velocity = newVelocity;
		}
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Destroyer") 
		{
			Destroy(gameObject);
		}
	}
}
