using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuScreen : MonoBehaviour {

	public GameObject MenuPanel;
	public GameObject ComingSoonPanel;
	public GameObject CustomizationPanel;
	public GameObject StorePanel;
	public GameObject levelselection;
	// Use this for initialization
	void Start () {
		
	}
	//=========================MainScreen====================//
	public void OnClickMenu()
	{
		SceneManager.LoadScene ("Demo");
	}

	public void OnClickLevel()
	{
		levelselection.SetActive (true);
		MenuPanel.SetActive (false);
		ComingSoonPanel.SetActive (false);
		CustomizationPanel.SetActive (false);
		StorePanel.SetActive (false);
	}
	public void OnClickOk()
	{
		
	}
	public void OnClickCustomize()
	{
		levelselection.SetActive (false);
		MenuPanel.SetActive (false);
		ComingSoonPanel.SetActive (false);
		CustomizationPanel.SetActive (true);
		StorePanel.SetActive (false);
	}
	//========================CustomizationPanel=================//
	public void OnClickColor()
	{
		
	}
	public void OnClickPattern()
	{
		
	}
	public void OnClickSymbol()
	{
		
	}
	public void OnClickStore()
	{
		
	}
	//===========================StorePanel======================//
	public void OnClickRemoveAds()
	{
		
	}
	public void OnClickBuyCoins()
	{
		
	}
	//==========================LevelSelection===================//
	public void OnclickLevel1()
	{
		


	}
	public void OnclickLevel2()
	{

	}
	public void OnclickLevel3()
	{

	}
	public void OnclickLevel4()
	{

	}
	public void OnclickLevel5()
	{

	}
	public void OnclickLevel6()
	{

	}
	public void MenuButton()
	{
		levelselection.SetActive (false);
		MenuPanel.SetActive (true);
		ComingSoonPanel.SetActive (false);
		CustomizationPanel.SetActive (false);
		StorePanel.SetActive (false);
	}
	//=============================Coming Soon======================//
	public void Testing123(string buttonName)
	{
		Debug.Log (buttonName);
	}
}
