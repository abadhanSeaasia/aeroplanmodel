using UnityEngine;
using System.Collections;

/*
Manages the creation of obstacles, enemies, bonuses and power-ups
*/

public class Generate : MonoBehaviour
{
	public GameObject rocks; // obstacle
	public GameObject enemies; // enemy
	public GameObject coins; // bonuses 
	public GameObject healts; // power-up
	public GameObject powerUps; // power-up
	public int createCoinsAfterNObstacles = 30;
	private Manager manager;
	public float SpawnInterval = 1.50f; //2.0f;
	private float _NextSpawn;
	private bool createdCoin = false;
	private int countObstacles = 0;
	
	// Use this for initialization
	void Start()
	{
		manager = GameObject.Find ("Scripts").GetComponent<Manager> ();
	}

	void FixedUpdate()
	{
		if (manager.startGame && !manager.deadPlayer) {
			if (Time.time >= _NextSpawn)
			{
				CreateObstacle();
				CreateEnemy();
				_NextSpawn = Time.time + SpawnInterval;
			}
		}
	}
	
	void CreateObstacle()
	{
		countObstacles++;
		GameObject rock = Instantiate(rocks) as GameObject;

		if (countObstacles >= createCoinsAfterNObstacles) {
			createdCoin = (Random.value >= 0.5f);
			if (createdCoin) {
				createdCoin = false;
				Transform rockDown = rock.transform.Find ("rockDown");
				if (rockDown) {
					if (Random.value >= 0.75f) {
						float x = rockDown.transform.position.x;
						float y = transform.position.y;
						for (int i = 0; i < 3; i++) {
							Vector3 newPos = new Vector3 (x + i, y, 0);
							CreateCoin (newPos);
						}
					}
					else {
						Vector3 newPos = new Vector3 (rockDown.transform.position.x, transform.position.y, 0);
						CreateCoin (newPos);						
						CreateHealtAndPowerUp(newPos);
					}
				}
			}
		}
	}

	void CreateEnemy()
	{
		bool create = (Random.value >= 0.75f);
		if (create)
		{
			Instantiate(enemies);
		}
	}

	void CreateCoin(Vector3 pos)
	{
		float posX = Random.Range (1.5f, 5.5f);
		float posY = Random.Range (-2.5f, 2.5f);
		Vector3 newPos = new Vector3 (pos.x + posX, pos.y + posY, 0);
		Instantiate (coins, newPos, Quaternion.identity);
	}

	void CreateHealtAndPowerUp(Vector3 pos) {
		float posX = Random.Range (1.5f, 5.5f);
		float posY = Random.Range (-2.5f, 2.5f);
		Vector3 newPos = new Vector3 (pos.x + posX, pos.y + posY, 0);
		if (Random.value >= 0.85f) {
			Instantiate (healts, newPos, Quaternion.identity);
		}
		else {
			if (Random.value >= 0.85f)
				Instantiate (powerUps, newPos, Quaternion.identity);
		}
	}

	IEnumerator invokeCreateObstacle(float seconds)
	{
		yield return new WaitForSeconds(seconds);
		CreateObstacle();
	}
}