using UnityEngine;
using System.Collections;

public class BtnPause : MonoBehaviour {

	public Sprite spriteClick;
	public GameObject spriteStart;
	public GameObject spritePause;
	
	private Sprite spriteOriginal;
	private BtnCommon btncommon;
	private Manager manager;

	// Use this for initialization
	void Start () {
		spriteOriginal = GetComponent<SpriteRenderer>().sprite;
		btncommon = GameObject.Find ("Scripts").GetComponent<BtnCommon> ();
		manager = GameObject.Find ("Scripts").GetComponent<Manager> ();
	}

	void OnMouseDownMobile() {
		btncommon.SoundClick3 ();
		
		btncommon.ChangeSpriteClick (GetComponent<SpriteRenderer> (), spriteOriginal, spriteClick);
		
		if (Time.timeScale > 0)
			Time.timeScale = 0;
		else
			Time.timeScale = 1;

		spriteStart.SetActive(false);
		spritePause.SetActive(true);
		manager.startGame = false;
		
	}
}
