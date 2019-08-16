using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
/*
concentrated functions and global variables of the game
Manages the state of the game and your score
*/
public class Manager : MonoBehaviour {
	
	public int score = 0; //It is updated by Player and Obstacle
	public int coinCount = 0; //It is updated by Player
	public int healtCount = 0; //It is updated by Player
	public int powerUpCount = 0; //It is updated by Player
	public bool deadPlayer = false; //It is updated by Player
	public bool startGame = false; //It is updated by TapSplash, when started
	public bool busyGame = false; //It is updated by buttons, so the player not answered while busy
	public String urlQuadrante = "http://www.quadrantestudio.com/";
	
	public Sprite[] spriteNumScoreGO; // sprite numbers in the score panel Gameover
	public Sprite[] spriteNumScore; // sprite numbers in the score
	
	public GameObject player; // Prefab
	public Vector3 startPoint;

	public float powerUpFlash = 1.0f; // manager by powerUpVelocity in Player.cs
	
	// control UI's
	private GameObject splash; // UI in scene main
	private GameObject gameover; // UI in scene main
	private GameObject pointsTxt; // UI in scene main
	private GameObject spriteHighScoreGO; // UI in scene main panel Gameover
	private GameObject spriteScoreGO; // UI in scene main panel Gameover
	private GameObject spriteHighScore; // UI in scene main
	private GameObject spriteScore; // UI in scene main
	private GameObject spriteCoinCount; // UI in scene main
	private GameObject spriteHealtCount; // UI in scene main

	private int scoreOld = -1; // control repaint in the scores
	private bool createdPlayer = false;
	private bool soundStartGame = false;
	private bool soundGameOver = false;
	private Sound sound; // Get control script sounds to others parts in game
	
	// Use this for initialization
	void Start () { // Get GameObject elements screen main
		sound = GameObject.Find ("Scripts").GetComponent<Sound> ();
		splash = GameObject.Find ("UI Elements/Splash") as GameObject;
		gameover = GameObject.Find("UI Elements/Gameover") as GameObject;
		pointsTxt = GameObject.Find("UI Elements/Points") as GameObject;
		spriteHighScoreGO = GameObject.Find ("UI Elements/Gameover/HighScore") as GameObject;
		spriteScoreGO = GameObject.Find ("UI Elements/Gameover/Score") as GameObject;
		spriteHighScore = GameObject.Find ("UI Elements/Points/scores/highScore") as GameObject;
		spriteScore = GameObject.Find ("UI Elements/Points/scores/score") as GameObject;
		spriteCoinCount = GameObject.Find("UI Elements/Points/powersUp/coin") as GameObject;
		spriteHealtCount = GameObject.Find("UI Elements/Points/powersUp/healt") as GameObject;
	}
	
	// Update is called once per frame
	void Update () {
		if (!startGame && !deadPlayer) {
			ShowSplash(true);
			ShowGameover(false);
			ShowPoints(false);
		}
		
		if (startGame && deadPlayer) {
			ShowGameover(true);
			ShowPoints(false);
			ShowSplash(false);
			if (!soundGameOver) {
				soundGameOver = true;
				SoundGameOver1();
				MakerScores(score, spriteScoreGO, new Vector2(0.0f, 0.0f), "MakerScoreGO", spriteNumScoreGO);
				MakerScores(PlayerPrefs.GetInt ("HighScore"), spriteHighScoreGO, new Vector2(0.0f, 0.0f), "MakerHighScoreGO", spriteNumScoreGO);
				MakerScores(coinCount, spriteCoinCount, new Vector2(-5.0f, 2.12f), "MakerCoinCount", spriteNumScoreGO);
				MakerScores(healtCount, spriteHealtCount, new Vector2(-5.0f, 1.56f), "MakerHealtCount", spriteNumScoreGO);
			}
		}
		
		if (startGame && !deadPlayer) {
			ShowPoints(true);
			ShowSplash(false);
			ShowGameover(false);
			if (!createdPlayer) {
				createdPlayer = true;
				Instantiate(player, startPoint, Quaternion.identity);
				MakerScores(PlayerPrefs.GetInt ("HighScore"), spriteHighScore, new Vector2(0.0f, 0.0f), "MakerHighScore", spriteNumScore);
				busyGame = true;
			}
			if (!soundStartGame) {
				soundStartGame = true;
				SoundStartGame1();
			}
			
		}
		
		if (score > PlayerPrefs.GetInt ("HighScore")) {
			PlayerPrefs.SetInt("HighScore", score);
		}
		
		if (Input.GetKey (KeyCode.Escape))
			Application.Quit ();
	}
	
	void FixedUpdate () {
		if (startGame && !deadPlayer) {
			if (scoreOld != score) { // control repaint in the scores
				scoreOld = score;
				MakerScores (score, spriteScore, new Vector2(0.0f, 0.0f), "MakerScore", spriteNumScore);
				MakerScores(coinCount, spriteCoinCount, new Vector2(-5.0f, 2.12f), "MakerCoinCount", spriteNumScore);
				MakerScores(healtCount, spriteHealtCount, new Vector2(-5.0f, 1.56f), "MakerHealtCount", spriteNumScore);
			}
		}
	}
	
	private int[] digitArr(int n)
	{
		if (n == 0) return new int[1] { 0 };
		
		var digits = new List<int>();
		
		for (; n != 0; n /= 10)
			digits.Add(n % 10);
		
		var arr = digits.ToArray();
		Array.Reverse(arr);
		return arr;
	}
	
	void DestroySpritesScores(String tag)
	{
		GameObject[] sprites = GameObject.FindGameObjectsWithTag(tag) as GameObject[];
		foreach (GameObject sprite in sprites)
		{
			Destroy(sprite);
		}
	}
	
	void MakerScores(int score, GameObject objScore, Vector2 posScore, String tag, Sprite[] spriteNumber){
		DestroySpritesScores(tag);
		float incX = 0.5f;
		int[] arrScore = digitArr(score);
		for (int i = 0; i < arrScore.Length; i++)
		{
			GameObject go = new GameObject(tag);
			go.tag = tag;
			go.transform.parent = objScore.transform;
			SpriteRenderer sr = go.AddComponent<SpriteRenderer>();
			sr.sprite = spriteNumber[arrScore[i]] as Sprite;
			sr.sortingOrder = 12;
			go.transform.localPosition = new Vector3((i * incX) + posScore.x, posScore.y, 0.0f); //localPosition em relacao ao pai
		}
	}
	
	void ShowSplash(bool visible){
		if (splash != null)
			splash.SetActive(visible);
	}
	
	void ShowGameover(bool visible){
		if (gameover != null)
			gameover.SetActive(visible);
	}
	
	void ShowPoints(bool visible){
		if (pointsTxt != null)
			pointsTxt.SetActive(visible);
	}
	
	public bool musicPlay
	{
		get
		{
			return sound.musicPlay;
		}
		set
		{
			sound.musicPlay = value;
		}
	}
	
	public bool soundPlay
	{
		get
		{
			return sound.soundPlay;
		}
		set
		{
			sound.soundPlay = value;
		}
	}
	
	public void SoundCoin1() {
		sound.SoundCoin1 ();
	}
	
	public void SoundCoin2() {
		sound.SoundCoin2 ();
	}
	
	public void SoundCoin3() {
		sound.SoundCoin3 ();
	}
	
	public void SoundCoin4() {
		sound.SoundCoin4 ();
	}
	
	public void SoundClick1() {
		sound.SoundClick1 ();
	}
	
	public void SoundClick2() {
		sound.SoundClick2 ();
	}
	
	public void SoundClick3() {
		sound.SoundClick3 ();
	}
	
	public void SoundDead1() {
		sound.SoundDead1 ();
	}
	
	public void SoundDead2() {
		sound.SoundDead2 ();
	}
	
	public void SoundDead3() {
		sound.SoundDead3 ();
	}
	
	public void SoundJumper1() {
		sound.SoundJumper1 ();
	}
	
	public void SoundJumper2() {
		sound.SoundJumper2 ();
	}
	
	public void SoundStartGame1() {
		sound.SoundStartGame1 ();
	}
	
	public void SoundGameOver1() {
		sound.SoundGameOver1 ();
	}
}
