using UnityEngine;
using System.Collections;

public class BtnPlay : MonoBehaviour {

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

		Application.LoadLevel ("scene-1");
	}
}
