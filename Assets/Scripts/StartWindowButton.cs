using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartWindowButton : MonoBehaviour {
	public GameObject start;
	public GameObject about;
	public GameObject settings;
	public GameObject heroSelect;
	// Use this for initialization
	/*
	void Start () {
		Button[] startBtns = start.GetComponentsInChildren<Button>();
		Debug.Log(startBtns.Length);
		for (int i = 0; i < startBtns.Length; i++)
		{
			int a = i;
			String desc = startBtns[a].name;
			Debug.Log(desc);
			startBtns[a].onClick.AddListener(delegate {StartPageButton(desc);});
		}
	}

	void StartPageButton(String name)
	{
		Debug.Log("Button " + name + " clicked");
		switch (name)
		{
			case "PlayButton":
			start.SetActive(false);
			heroSelect.SetActive(true);
			break;
			case "RankingsButton":
			break;
			case "BadgesButton":
			break;
			case "AboutButton":
			break;
			case "ButtonSettings":
			settings.SetActive(true);
			break;
			case "ButtonExit":
			break;
			default:
			break;
		}
	}*/
	public void PlayButton()
	{
		start.SetActive(false);
		heroSelect.SetActive(true);
	}

	public void RankingsButton()
	{

	}

	public void BadgesButton()
	{

	}

	public void AboutButton()
	{
		start.SetActive(false);
		about.SetActive(true);
	}

	public void SettingsButton() {
		settings.SetActive(true);
	}

	public void ExitButton()
	{
		
	}
}
