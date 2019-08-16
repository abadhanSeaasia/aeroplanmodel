using UnityEngine;
using System.Collections;

public class BtnGunNumber1 : MonoBehaviour {

	public Sprite spriteClick;
	public Rigidbody2D rocket;				// Prefab of the rocket.
	public float speed = 20f;				// The speed the rocket will fire at.

	private Sprite spriteOriginal;
	private BtnCommon btncommon;
	GameObject player;
	
	// Use this for initialization
	void Start () {
		spriteOriginal = GetComponent<SpriteRenderer>().sprite;
		btncommon = GameObject.Find ("Scripts").GetComponent<BtnCommon> ();
	}
	
	// Update is called once per frame
	void Update () {
		RuntimePlatform platform = Application.platform;
		if (platform != RuntimePlatform.Android && platform != RuntimePlatform.IPhonePlayer) {
			if (Input.GetKeyDown(KeyCode.LeftControl)) // platform web and desktop
				OnMouseDownMobile();
		}
	}
	
	void OnMouseDownMobile() {
		btncommon.SoundClick3 ();
		
		btncommon.ChangeSpriteClick (GetComponent<SpriteRenderer> (), spriteOriginal, spriteClick);

		player = GameObject.FindGameObjectWithTag("Player");
		Rigidbody2D bulletInstance = Instantiate(rocket, player.transform.position, Quaternion.Euler(new Vector3(0,0,0))) as Rigidbody2D;
		bulletInstance.velocity = new Vector2(speed, 0);
	}
}
