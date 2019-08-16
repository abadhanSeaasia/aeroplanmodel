using UnityEngine;
using System.Collections;
/*
Manages the functions of music and game sound
Stores state action PlayerPrefs (music and sound)
*/
public class Sound : MonoBehaviour {

	public AudioClip[] sounds; // vector all sounds and musics

	private AudioClip audioBackground;
	private bool _musicPlay = true;
	private bool _soundPlay = true;

	private AudioClip coin1 = null;
	private AudioClip coin2 = null;
	private AudioClip coin3 = null;
	private AudioClip coin4 = null;
	private AudioClip dead1 = null;
	private AudioClip dead2 = null;
	private AudioClip dead3 = null;
	private AudioClip click1 = null;
	private AudioClip click2 = null;
	private AudioClip click3 = null;
	private AudioClip jumper1 = null;
	private AudioClip jumper2 = null;
	private AudioClip startgame1 = null;
	private AudioClip gameover1 = null;

	// Use this for initialization
	void Start () {
		coin1 = GetSound ("Coin1");
		coin2 = GetSound ("Coin2");
		coin3 = GetSound ("Coin3");
		coin4 = GetSound ("Coin4");
		dead1 = GetSound ("Dead1");
		dead2 = GetSound ("Dead2");
		dead3 = GetSound ("Dead3");
		click1 = GetSound ("Click1");
		click2 = GetSound ("Click2");
		click3 = GetSound ("Click3");
		jumper1 = GetSound ("Jumper1");
		jumper2 = GetSound ("Jumper2");
		startgame1 = GetSound ("StartGame1");
		gameover1 = GetSound ("GameOver1");
		_musicPlay = !(PlayerPrefs.GetInt("MusicPlay") == 2); //se for 2, entao sera false
		_soundPlay = !(PlayerPrefs.GetInt("SoundPlay") == 2); //se for 2, entao sera false
	}

	public bool musicPlay
	{
		get
		{
			return _musicPlay;
		}
		set
		{
			_musicPlay = value;
			if (_musicPlay) {
				GetComponent<AudioSource>().Play();
				PlayerPrefs.SetInt("MusicPlay", 1);
			}
			else{
				GetComponent<AudioSource>().Stop();
				PlayerPrefs.SetInt("MusicPlay", 2);
			}
		}
	}

	public bool soundPlay
	{
		get
		{
			return _soundPlay;
		}
		set
		{
			_soundPlay = value;
			if (_soundPlay) {
				PlayerPrefs.SetInt("SoundPlay", 1);
			}
			else{
				PlayerPrefs.SetInt("SoundPlay", 2);
			}
		}
	}

	private AudioClip GetSound(string name){
		AudioClip sound = null;
		if (sounds != null && sounds.Length > 0) {
			for(int i = 0; i < sounds.Length; i++)
			{
				if (sounds[i].name.Contains(name)) {
					sound = sounds[i];
					break;
				}
			}
		}
		return sound;
	}

	private void ExecuteSound(AudioClip sound) {
		if (_soundPlay)
			AudioSource.PlayClipAtPoint (sound, Camera.main.transform.position);
	}

	private void ExecuteSoundBackground(AudioClip sound) {
			GetComponent<AudioSource>().Stop ();
			GetComponent<AudioSource>().clip = sound;
		if (_musicPlay) {
			GetComponent<AudioSource>().Play ();
		}
	}

	public void SoundCoin1() {
		ExecuteSound (coin1);			
	}
	
	public void SoundCoin2() {
		ExecuteSound (coin2);
	}

	public void SoundCoin3() {
		ExecuteSound (coin3);
	}

	public void SoundCoin4() {
		ExecuteSound (coin4);
	}

	public void SoundDead1() {
		ExecuteSound (dead1);
	}
	
	public void SoundDead2() {
		ExecuteSound (dead2);
	}

	public void SoundDead3() {
		ExecuteSound (dead3);
	}

	public void SoundClick1() {
		ExecuteSound (click1);
	}
	
	public void SoundClick2() {
		ExecuteSound (click2);
	}

	public void SoundClick3() {
		ExecuteSound (click3);
	}

	public void SoundJumper1() {
		ExecuteSound (jumper1);
	}

	public void SoundJumper2() {
		ExecuteSound (jumper2);
	}

	public void SoundStartGame1() {
		ExecuteSoundBackground (startgame1);
	}

	public void SoundGameOver1() {
		ExecuteSoundBackground (gameover1);
	}
}
