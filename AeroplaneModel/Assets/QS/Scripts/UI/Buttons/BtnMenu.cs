using UnityEngine;
using System.Collections;

public class BtnMenu : MonoBehaviour {

	public Sprite spriteClick;

	private Sprite spriteOriginal;
	private BtnCommon btncommon;
	
	// Use this for initialization
	void Start () {
		spriteOriginal = GetComponent<SpriteRenderer>().sprite;
		btncommon = GameObject.Find ("Scripts").GetComponent<BtnCommon> ();
	}
	
	void OnMouseDownMobile() {
		btncommon.SoundClick3 ();

		btncommon.ChangeSpriteClick (GetComponent<SpriteRenderer> (), spriteOriginal, spriteClick);
		if (Time.timeScale < 1)
			Time.timeScale = 1;
		Application.LoadLevel ("scene-menu");
	}
}
