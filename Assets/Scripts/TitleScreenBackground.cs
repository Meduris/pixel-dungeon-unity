using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreenBackground : MonoBehaviour {
	public float scrollSpeedSmall;
	public float scrollSpeedBig;

	public GameObject big1;
	public GameObject big2;
	public GameObject small1;
	public GameObject small2;

	private Vector3 startPos_big1;
	private Vector3 startPos_big2;
	private Vector3 startPos_small1;
	private Vector3 startPos_small2;

	private Vector2 spriteSize;

	private float worldScreenHeight;
	private float worldScreenWidth;

	void Start () {
		startPos_big1 = big1.transform.position;
		startPos_small1 = small1.transform.position;
		worldScreenHeight = Camera.main.orthographicSize * 2.0f;
		worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;
		spriteSize = new Vector2(worldScreenWidth * .32f + .32f, worldScreenHeight * .32f + .32f);
		big1.GetComponent<SpriteRenderer>().size = spriteSize;
		small1.GetComponent<SpriteRenderer>().size = spriteSize;
		big2.GetComponent<SpriteRenderer>().size = spriteSize;
		small2.GetComponent<SpriteRenderer>().size = spriteSize;

		startPos_big2 = startPos_big1 + (worldScreenHeight + .56f) * Vector3.down;
		startPos_small2 = startPos_small1 + (worldScreenHeight + .56f) * Vector3.down;

		big2.transform.position = startPos_big2;
		small2.transform.position = startPos_small2;
	}
	
	void Update () {
		float newPosSmall = Mathf.Repeat(Time.time * scrollSpeedSmall, worldScreenHeight + .56f);
		float newPosBig = Mathf.Repeat(Time.time * scrollSpeedBig, worldScreenHeight + .56f);
		big1.transform.position = startPos_big1 + newPosBig * Vector3.up;
		big2.transform.position = startPos_big2 + newPosBig * Vector3.up;
		small1.transform.position = startPos_small1 + newPosSmall * Vector3.up;
		small2.transform.position = startPos_small2 + newPosSmall * Vector3.up;
	}
}