using UnityEngine;
using System.Collections;

public class Rocket : MonoBehaviour 
{
	public GameObject explosion;		// Prefab of explosion effect.

	private Manager manager;

	void Start () 
	{
		// Destroy the rocket after 5 seconds if it doesn't get destroyed before then.
		manager = GameObject.Find ("Scripts").GetComponent<Manager> ();
		Destroy(gameObject, 5);
	}


	void OnExplode()
	{
		// Create a quaternion with a random rotation in the z-axis.
		Quaternion randomRotation = Quaternion.Euler(0f, 0f, Random.Range(0f, 360f));

		explosion.GetComponent<AudioSource>().playOnAwake = manager.soundPlay;

		// Instantiate the explosion where the rocket is with the random rotation.
		Instantiate(explosion, transform.position, randomRotation);
	}
	
	void OnTriggerEnter2D (Collider2D col) 
	{
		// If it hits an enemy...
		if(col.tag == "RockUp")
		{
			// ... find the Enemy script and call the Hurt function.
			col.gameObject.GetComponentInParent<Obstacle>().Hurt();

			// Call the explosion instantiation.
			OnExplode();

			// Destroy the rocket.
			Destroy (gameObject);
		}
		else if(col.tag == "Enemy")
		{
			// ... find the Enemy script and call the Hurt function.
			col.gameObject.GetComponentInParent<Enemy>().Hurt();
			
			// Call the explosion instantiation.
			OnExplode();
			
			// Destroy the rocket.
			Destroy (gameObject);
		}
		else if ((col.tag == "Coin") || (col.tag == "Healt") || (col.tag == "PowerUp"))
		{
			//none
		}
		// Otherwise if it hits a bomb crate...
		else if(col.tag == "BombPickup")
		{
			// Destroy the bomb crate.
			Destroy (col.transform.root.gameObject);

			// Destroy the rocket.
			Destroy (gameObject);
		}
		// Otherwise if the player manages to shoot himself...
		else if ((col.gameObject.tag != "Player") && (col.gameObject.tag != "Untagged") && (col.gameObject.tag != "Passage"))
		{
			// Instantiate the explosion and destroy the rocket.
			OnExplode();
			Destroy (gameObject);
		}
	}
}
