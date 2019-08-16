using UnityEngine;
using System.Collections;

public class BtnMusic : MonoBehaviour {

	public Sprite spriteClickOriginal;
	public Sprite spriteClickOrange;
	public Sprite spriteClickRed;
	private BtnCommon btncommon;
	private Manager manager;
	private int changeMusicPlay;
	private int changeSoundPlay;

	// Use this for initialization
	void Start () {
		btncommon = GameObject.Find ("Scripts").GetComponent<BtnCommon> ();

		changeMusicPlay = PlayerPrefs.GetInt ("MusicPlay");
		changeSoundPlay = PlayerPrefs.GetInt ("SoundPlay");
		if (changeMusicPlay == 2 && changeSoundPlay == 2) {
			btncommon.ChangeSpriteClick (GetComponent<SpriteRenderer> (), spriteClickRed);
		} else if (changeMusicPlay == 2 && changeSoundPlay != 2) {
			btncommon.ChangeSpriteClick (GetComponent<SpriteRenderer> (), spriteClickOrange);
		} else {
			btncommon.ChangeSpriteClick (GetComponent<SpriteRenderer> (), spriteClickOriginal);
		}

		manager = GameObject.Find ("Scripts").GetComponent<Manager> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (changeMusicPlay != PlayerPrefs.GetInt ("MusicPlay") || changeSoundPlay != PlayerPrefs.GetInt ("SoundPlay")) {
			if (PlayerPrefs.GetInt ("MusicPlay") == 2 && PlayerPrefs.GetInt ("SoundPlay") == 2) {
				btncommon.ChangeSpriteClick (GetComponent<SpriteRenderer> (), spriteClickRed);
			} else if (PlayerPrefs.GetInt ("MusicPlay") == 2 && PlayerPrefs.GetInt ("SoundPlay") != 2) {
				btncommon.ChangeSpriteClick (GetComponent<SpriteRenderer> (), spriteClickOrange);
			} else {
				btncommon.ChangeSpriteClick (GetComponent<SpriteRenderer> (), spriteClickOriginal);
			}
		}
	}

	void OnMouseDownMobile() {
		btncommon.SoundClick3 ();

		manager.busyGame = true;

		if (manager.musicPlay && manager.soundPlay) {
			manager.musicPlay = false;
			btncommon.ChangeSpriteClick (GetComponent<SpriteRenderer> (), spriteClickOrange);
		} else if (!manager.musicPlay && manager.soundPlay) {
			manager.soundPlay = false;
			btncommon.ChangeSpriteClick (GetComponent<SpriteRenderer> (), spriteClickRed);
		} else {
			manager.musicPlay = true;
			manager.soundPlay = true;
			btncommon.ChangeSpriteClick (GetComponent<SpriteRenderer> (), spriteClickOriginal);
		}
	}
}
