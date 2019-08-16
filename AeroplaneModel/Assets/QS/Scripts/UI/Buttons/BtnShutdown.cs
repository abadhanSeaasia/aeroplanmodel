using UnityEngine;
using System.Collections;

public class BtnShutdown : MonoBehaviour {

	public Sprite spriteClick;

	void OnMouseDownMobile() {		
		#if UNITY_EDITOR
			UnityEditor.EditorApplication.isPlaying = false;
		#elif UNITY_WEBPLAYER
			string webplayerQuitURL = "http://www.quadrantestudio.com";
			Application.OpenURL(webplayerQuitURL);
		#else
			Application.Quit();
		#endif
	}
}
