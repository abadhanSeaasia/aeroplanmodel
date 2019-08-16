using UnityEngine;
using System.Collections;

public class BtnResetScore : MonoBehaviour {

	public Sprite spriteClick;
	public Sprite spriteMessage;
	public float _IntervalSpriteMessage = 0.75f;

	private Sprite spriteOriginal; 
	private float _NextSpriteMessage;
	private BtnCommon btncommon;
	
	// Use this for initialization
	void Start () {
		spriteOriginal = GetComponent<SpriteRenderer>().sprite;
		btncommon = GameObject.Find ("Scripts").GetComponent<BtnCommon> ();
	}

	void OnMouseDownMobile() {
		btncommon.SoundClick3 ();

		btncommon.ChangeSpriteClick (GetComponent<SpriteRenderer> (), spriteOriginal, spriteClick);

		PlayerPrefs.SetInt ("HighScore", 0);

		if (Time.time >= _NextSpriteMessage) {
			Vector3 centerPoint = Camera.main.ScreenToWorldPoint (new Vector3 (Camera.main.pixelWidth / 2, Camera.main.pixelHeight / 2, 1));
			GameObject go = new GameObject ("spriteMessage");
			go.transform.localScale = new Vector3 (1.5f, 1.5f, 1.0f);
			SpriteRenderer sr = go.AddComponent<SpriteRenderer> ();
			sr.sprite = spriteMessage;
			sr.sortingOrder = 1;
			go.transform.position = centerPoint; //localPosition em relacao ao pa
			Destroy (go, _IntervalSpriteMessage);
			_NextSpriteMessage = Time.time + _IntervalSpriteMessage;
		}
	}
}
