using UnityEngine;
using System.Collections;

public class move: MonoBehaviour {

	float speed = 1.0f;
	public Transform lookpoint;
	public GameObject cube;
	public float smooth = 2.0F;
	public float tiltAngle = 30.0F;
	public GameObject GameOverpanel;
	public float RotateUpSpeed = 1, RotateDownSpeed = 1;
	Vector3 birdRotation = Vector3.zero;
	public float rotationvalue;
	void Update() {
		
		
		//var move = new Vector3(0, Input.GetAxis("Vertical"),0);
		//transform.position += move * speed * Time.deltaTime*2;

		float tiltAroundX = rotationvalue * tiltAngle;
		Quaternion target = Quaternion.Euler(0, 0, tiltAroundX);
		transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);

	}
	void OnCollisionEnter2D(Collision2D coll) 
	{
		if (coll.gameObject.tag == "Enemy")
		{
			GameOverpanel.SetActive (true);
			Time.timeScale = 0;
		}
		if (coll.gameObject.tag == "coin")
		{

			Destroy (coll.gameObject);
		}
			

	}

}