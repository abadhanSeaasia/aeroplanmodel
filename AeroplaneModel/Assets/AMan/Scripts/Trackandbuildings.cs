using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Trackandbuildings : MonoBehaviour {

	public GameObject Track;
	public GameObject plane;
	public bool isflight;
	public bool IsInst;
	public bool IsInstPendulam;
	public GameObject[] tower;
	public GameObject Coin;
	private GameObject CoinStorage;
	public GameObject Pendulam;
	Rigidbody2D rb;


	// Use this for initialization
	void Start () 
	{
		IsInst = true;
		rb = plane.GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
 		Track.transform.Translate(-0.1f, 0, 0, Space.World);
		if (plane.transform.position.y > 2) 
		{
			//plane.GetComponent<move> ().enabled = true;
			isflight = true;
		}
		if (!isflight) 
		{
			plane.transform.Translate (0, 0.09f, 0, Space.World);
		}
		if (IsInst) 
		{
			
			StartCoroutine ("delay");
		}

	}
	IEnumerator delay()
	{
		IsInst = false;
		yield return new WaitForSeconds (0.9f);
		var R_value = Random.Range (0, 4);
		print (R_value);
		switch (R_value) {
		case 0:
			var a1 = Instantiate (tower [Random.Range (0, 3)], new Vector3 (10f, Random.Range (-1.1f, -3.7f), 0f), Quaternion.identity);
			CoinStorage = Instantiate (Coin, new Vector3 (a1.transform.position.x , a1.transform.position.y+5, 0f), Quaternion.identity);
			a1.transform.parent = this.transform;
			CoinStorage.transform.parent = this.transform;
			break;
		case 1:
			var b1 = Instantiate (Pendulam, new Vector3 (10f, Random.Range (5.3f, 6.3f), 0), Quaternion.identity);
			CoinStorage = Instantiate (Coin, new Vector3 (b1.transform.position.x , b1.transform.position.y-5, 0f), Quaternion.identity);
			b1.transform.parent = this.transform;
			CoinStorage.transform.parent = this.transform;
			break;
		case 2:
			var a2 = Instantiate(tower[Random.Range(0,3)], new Vector3(10f, Random.Range(-1.1f,-3.7f), 0f), Quaternion.identity);
			CoinStorage = Instantiate (Coin, new Vector3 (a2.transform.position.x , a2.transform.position.y+5, 0f), Quaternion.identity);
			a2.transform.parent = this.transform;
			CoinStorage.transform.parent = this.transform;
			break;
		case 3:
			var b2 = Instantiate (Pendulam, new Vector3 (10f, Random.Range (5.3f, 6.3f), 0), Quaternion.identity);
			CoinStorage = Instantiate (Coin, new Vector3 (b2.transform.position.x , b2.transform.position.y-5, 0f), Quaternion.identity);
			b2.transform.parent = this.transform;
			CoinStorage.transform.parent = this.transform;
			break;
		}
		//var a = Instantiate(tower[Random.Range(0,3)], new Vector3(14.7f, Random.Range(-1.1f,-3.7f), 0f), Quaternion.identity);
		//a.transform.parent = this.transform;
		IsInst = true;


	}

	public void onDown()
	{
		//rb.AddForce(transform.up * Time.fixedDeltaTime*1);
		rb.velocity = new Vector3(0, -1.6F, 0);
		plane.GetComponent<move> ().rotationvalue = -0.8f;
	}

	public void onUp()
	{
		//rb.AddForce(transform.up * Time.fixedDeltaTime*-1);
		rb.velocity = new Vector3(0, 1.5f, 0);
		plane.GetComponent<move> ().rotationvalue = 0.8f;
	}
	public void onUprelease()
	{
		rb.velocity = new Vector3(0, -1f, 0);
		plane.GetComponent<move> ().rotationvalue = -0.8f;
	}
	public void retry()
	{
		Time.timeScale = 1;
		SceneManager.LoadScene ("Demo");
	}
}
