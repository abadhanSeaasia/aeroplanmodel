using UnityEngine;
using System.Collections;

public class BtnQuadrante : MonoBehaviour {

	private BtnCommon btncommon;
	private Manager manager;
	
	// Use this for initialization
	void Start () {
		btncommon = GameObject.Find ("Scripts").GetComponent<BtnCommon> ();
		manager = GameObject.Find ("Scripts").GetComponent<Manager> ();
	}
	
	void OnMouseDownMobile() {
		btncommon.SoundClick3 ();
		Application.OpenURL (manager.urlQuadrante);
	}
}
