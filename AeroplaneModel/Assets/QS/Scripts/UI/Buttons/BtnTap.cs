using UnityEngine;
using System.Collections;

public class BtnTap : MonoBehaviour {

	public Sprite spriteClick;

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
		
		manager.busyGame = false;
	}

}
