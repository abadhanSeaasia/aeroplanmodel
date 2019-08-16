using UnityEngine;
using System.Collections;


public class Player : MonoBehaviour
{
	// The force which is added when the player jumps
	// This can be changed in the Inspector window
	public Vector2 jumpForce = new Vector2(0, 300);
	public GameObject playerDead;
	public float divVelocity;
	public bool IgnoreDead = false; //para testes internos, assim nao precisa ficar reiniciando
	public float pos = 0f;
	public GameObject explosion;		// Prefab of explosion effect.
	public GameObject bubble;

	private float anglePlayer = 0;
	private bool keyPress = false;
	private Manager manager;
	private int blinkPlayer = 0;
	private bool powerUpOn = false;
	private float powerUpVelocity = 0.35f;

	// Use this for initialization
	void Start () {
		manager = GameObject.Find ("Scripts").GetComponent<Manager> ();
		bubble.SetActive(false);
	}

	// Update is called once per frame
	void Update ()
	{
		// Jump
		if (manager.startGame && !manager.deadPlayer && Input.anyKeyDown)// GetKeyUp("space"))
		{
			keyPress = !manager.busyGame;
		}

		transform.eulerAngles = new Vector3 (0, 0, anglePlayer);		
		// Die by being off screen
		Vector2 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
		if (screenPosition.y > (Screen.height - 0) || screenPosition.y < 0)
		{
			Die();
		}
		pos += divVelocity * Time.deltaTime;
	}

	void FixedUpdate()
	{
		if (keyPress) {
			manager.busyGame = true;
			keyPress = false;
			manager.SoundJumper2();
			GetComponent<Rigidbody2D>().velocity = Vector2.zero;
			GetComponent<Rigidbody2D>().AddForce (jumpForce);
		}

		if (GetComponent<Rigidbody2D>().velocity.y < 0) {
			anglePlayer = Mathf.Lerp (0, -55, -GetComponent<Rigidbody2D>().velocity.y / divVelocity);
		} else {
			anglePlayer = Mathf.Lerp (0, 25, GetComponent<Rigidbody2D>().velocity.y / divVelocity);
		}

		if ((blinkPlayer > 0) && ((blinkPlayer % 2) == 0)) {
			blinkPlayer = blinkPlayer - 2;
			gameObject.GetComponent<SpriteRenderer>().enabled = !gameObject.GetComponent<SpriteRenderer>().enabled; //This toggles it
		}
		else {
			gameObject.GetComponent<SpriteRenderer>().enabled = true;
		}
	}

	// Die by collision
	void OnCollisionEnter2D(Collision2D other)
	{
		//Debug.Log (other.gameObject.tag);
		if (!IgnoreDead) {
			if (other.gameObject.tag == "Player") {
				Destroy (other.gameObject.gameObject.gameObject);
			}
			else {
				if (other.gameObject.tag != "Untagged") {

					if ((other.gameObject.tag == "Enemy") || (other.gameObject.tag == "rock")) {
						Destroy(other.gameObject);
					}

					if ((manager.powerUpCount > 0) || (powerUpOn)) { // powerup eh verificado primeiro
						manager.powerUpCount--;						
						manager.score = manager.score + 10; //mesmo peso do powerup (quando obtem o powerup)
					}
					else if (manager.healtCount > 0) {
						manager.healtCount--;
						blinkPlayer = 40;
					}
					else {
						Die ();
					}

				}
			}
		}
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Passage") 
		{
			manager.SoundCoin4();
			manager.score++;
		}
		if (other.tag == "Coin") {
			manager.SoundCoin2();
			manager.score = manager.score + 5;
			manager.coinCount++;
			Destroy(other.gameObject);
		}
		if (other.tag == "Healt") {
			manager.SoundCoin2();
			manager.score = manager.score + 15;
			manager.healtCount++;
			Destroy(other.gameObject);
		}
		if (other.tag == "PowerUp") {
			manager.SoundCoin2();
			manager.score = manager.score + 10;
			manager.powerUpCount++;
			manager.powerUpFlash = manager.powerUpFlash + powerUpVelocity;
			bubble.SetActive(true);
			powerUpOn = true;
			StartCoroutine(PowerUpOff());
			Destroy(other.gameObject);
		}
	}
	
	void Die()
	{
		manager.deadPlayer = true;
		Instantiate (playerDead, transform.position, Quaternion.identity);
		Destroy (gameObject);
	}

	void OnExplode()
	{
		// Create a quaternion with a random rotation in the z-axis.
		Quaternion randomRotation = Quaternion.Euler(0f, 0f, Random.Range(0f, 360f));

		explosion.GetComponent<AudioSource>().playOnAwake = manager.soundPlay;
		// Instantiate the explosion where the rocket is with the random rotation.
		Instantiate(explosion, transform.position, randomRotation);
	}

	IEnumerator PowerUpOff()
	{
		yield return new WaitForSeconds (5.0f);
		blinkPlayer = 100;
		yield return new WaitForSeconds (2.0f);
		powerUpOn = false; 
		bubble.SetActive(false);
		manager.powerUpFlash = manager.powerUpFlash - powerUpVelocity;	
	}

}
