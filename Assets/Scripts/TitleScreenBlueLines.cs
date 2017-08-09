using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreenBlueLines : MonoBehaviour {
	public float alphaChange;
	private SpriteRenderer rnd;
	// Use this for initialization
	void Start () {
		rnd = GetComponentInChildren<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		rnd.color = new Color(rnd.color.r, rnd.color.g, rnd.color.b, rnd.color.a + alphaChange);
	}
}
