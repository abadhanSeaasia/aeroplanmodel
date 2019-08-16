using UnityEngine;
using System.Collections;
/*
focus common functions related to the buttons.
Detect platform image exchange to occur one click, play sounds and other
*/

public class BtnCommon : MonoBehaviour {

	private Manager manager;

	// Use this for initialization
	void Start () {
		manager = GameObject.Find ("Scripts").GetComponent<Manager> ();
	}

	// Update is called once per frame
	void Update () {
		DetectPlataformClick ();
	}

	public void DetectPlataformClick() {
		RuntimePlatform platform = Application.platform;
		if (platform == RuntimePlatform.Android || platform == RuntimePlatform.IPhonePlayer) {
			int i = 0;
			while (i < Input.touchCount) {
				if (Input.GetTouch (i).phase == TouchPhase.Began)
				{
					DetectClick (Input.GetTouch (i).position);	
				}
				++i;
			}

		} else if (platform == RuntimePlatform.WindowsEditor) {
			// Across different platforms Android and IOS to simulate the click of the rocket, use Ctrl Left button (BtnGunNumber1.cs)
			if (Input.GetMouseButtonDown (0)) {
				DetectClick (Input.mousePosition);
			}
		}
	}

	public void DetectClick(Vector3 pos) {
		Vector3 org = Camera.main.ScreenToWorldPoint (pos);

		Vector2 dir = Vector2.zero;
		RaycastHit2D hit = Physics2D.Raycast (org, dir);
		if (hit.collider != null)
			// For the use of the rocket buttons and jump, necessary to call event OnMouseDownMobile, instead of OnMouseDown Default
			hit.collider.SendMessage ("OnMouseDownMobile", null, SendMessageOptions.RequireReceiver);
	}

	public void ChangeSpriteClick(SpriteRenderer render, Sprite newSprite){
		StartCoroutine(invokeChangeSprite(0.15f, render, newSprite));
	}

	public void ChangeSpriteClick(SpriteRenderer render, Sprite oldSprite, Sprite newSprite){
		StartCoroutine(invokeChangeSprite(0.15f, render, oldSprite, newSprite));
	}

	IEnumerator invokeChangeSprite(float seconds, SpriteRenderer render, Sprite oldSprite, Sprite newSprite)
	{
		render.sprite = newSprite;
		yield return new WaitForSeconds(seconds);
		render.sprite = oldSprite;
	}

	IEnumerator invokeChangeSprite(float seconds, SpriteRenderer render, Sprite newSprite)
	{
		yield return new WaitForSeconds(seconds);
		render.sprite = newSprite;
	}

	public void SoundClick1() {
		manager.SoundClick1 ();
	}

	public void SoundClick2() {
		manager.SoundClick2 ();
	}

	public void SoundClick3() {
		manager.SoundClick3 ();
	}
}
