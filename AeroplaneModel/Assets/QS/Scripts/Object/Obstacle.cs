using UnityEngine;

public class Obstacle : MonoBehaviour
{
	public Vector2 velocity = new Vector2(-4f, 0);
	public int HP = 2;					// How many times the enemy can be hit before it dies.
	public Sprite damagedEnemy;			// An optional sprite of the enemy when it's damaged.

	private float heigthRange;
	private Manager manager;
	private bool moveY;
	private float velocityY = 0;
	private bool downY = true;
	private SpriteRenderer ren;			// Reference to the sprite renderer.
	
	// Use this for initialization
	void Start()
	{
		ren = transform.Find("rock").GetComponent<SpriteRenderer>();
		manager = GameObject.Find ("Scripts").GetComponent<Manager> ();
		GetComponent<Rigidbody2D>().velocity = velocity;
		heigthRange = Random.Range (-0.70f, -3.02f);
		transform.position = new Vector3(transform.position.x, heigthRange, transform.position.z);
		moveY = (Random.value > 0.75f);// maior que 0.75 = true
	}

	void Update()
	{
		if (manager.startGame && manager.deadPlayer) {
			GetComponent<Rigidbody2D>().velocity = Vector2.zero;
		} else {
			if (moveY) {
				GetComponent<Rigidbody2D>().velocity = new Vector2 ((velocity.x * manager.powerUpFlash), velocityY);
			}
		}
	}

	void FixedUpdate(){
		if (manager.startGame && !manager.deadPlayer) {
			if (moveY) {
				if (downY) {
					velocityY = Random.Range(-1.0f, -2.50f);// -1.75f;
					if (transform.position.y <= -3.02f){
						downY = false;
					}
				} else {
					velocityY = Random.Range(1.0f, 2.50f);// 1.75f;
					if (transform.position.y >= -0.70f) {
						downY = true;
					}
				}
			} else {
				velocityY = 0;
			}
			// If the enemy has one hit point left and has a damagedEnemy sprite...
			if(HP == 1 && damagedEnemy != null)
				// ... set the sprite renderer's sprite to be the damagedEnemy sprite.
				ren.sprite = damagedEnemy;
			
			// If the enemy has zero or fewer hit points and isn't dead yet...
			if(HP <= 0)
				// ... call the death function.
				Death ();
		}
	}

	public void Hurt()
	{
		// Reduce the number of hit points by one.
		HP--;
	}

	void Death()
	{
		manager.score--;
		Destroy (gameObject);
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Destroyer") 
		{
			Destroy(gameObject);
		}
	}
}