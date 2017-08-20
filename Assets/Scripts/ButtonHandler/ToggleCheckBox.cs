using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleCheckBox : MonoBehaviour {
	public Sprite checkedImg;
	public Sprite uncheckedImg;

	public GameObject checkBox;
	private bool ticked = true;

	public void toggleCheckBox() {
		ticked = !ticked;
		if (ticked)
			checkBox.GetComponent<Image>().sprite = checkedImg;
		else
			checkBox.GetComponent<Image>().sprite = uncheckedImg;
	}
}
