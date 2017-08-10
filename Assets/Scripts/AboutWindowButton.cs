using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AboutWindowButton : MonoBehaviour {
	public GameObject start;
	public GameObject about;

	public void BackButton()
	{
		start.SetActive(true);
		about.SetActive(false);
	}

	public void HomePageButton()
	{
		Application.OpenURL("http://pixeldungeon.watabou.ru");
	}
}