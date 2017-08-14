using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreenBackground : MonoBehaviour {
	public GameObject arc_small;
	public GameObject arc_big;
	public float scrollSpeedSmall;
	public float scrollSpeedBig;
	public int tileSizeSmall;
	public int tileSizeBig;
	public float smallOffset = 0.95f;
	public float bigOffset = 1.9f;

	public GameObject big1;
	public GameObject big2;
	public GameObject small1;
	public GameObject small2;

	private Vector3 startPos_big1;
	private Vector3 startPos_big2;
	private Vector3 startPos_small1;
	private Vector3 startPos_small2;

	private GameObject[,] big_arcs;
	private GameObject[,] small_arcs;

	private Vector2 spriteSize;

	void Start () {
		//initArcs(out small_arcs, arc_small, tileSizeSmall, smallOffset);
		//initArcs(out big_arcs, arc_big, tileSizeBig, bigOffset);
		startPos_big1 = big1.transform.position;
		startPos_small1 = small1.transform.position;
		float camHeight = Camera.main.pixelHeight / 200f;
		float camWidth = Camera.main.pixelWidth / 200f;
		spriteSize = new Vector2(camWidth, camHeight);
		big1.GetComponent<SpriteRenderer>().size = spriteSize;
		small1.GetComponent<SpriteRenderer>().size = spriteSize;
		big2.GetComponent<SpriteRenderer>().size = spriteSize;
		small2.GetComponent<SpriteRenderer>().size = spriteSize;

		startPos_big2 = startPos_big1 + (spriteSize.y * 3) * Vector3.down;
		startPos_small2 = startPos_small1 + (spriteSize.y * 3) * Vector3.down;

		big2.transform.position = startPos_big2;
		small2.transform.position = startPos_small2;
	}
	
	// Update is called once per frame
	void Update () {
		//updatePosition(small_arcs, scrollSpeedSmall, smallOffset);
		//updatePosition(big_arcs, scrollSpeedBig, bigOffset);
		float newPosSmall = Mathf.Repeat(Time.time * scrollSpeedSmall, spriteSize.y);
		float newPosBig = Mathf.Repeat(Time.time * scrollSpeedBig, spriteSize.y);
		big1.transform.position = startPos_big1 + newPosBig * Vector3.up;
		big2.transform.position = startPos_big2 + newPosBig * Vector3.up;
		small1.transform.position = startPos_small1 + newPosSmall * Vector3.up;
		small2.transform.position = startPos_small2 + newPosSmall * Vector3.up;
	}

	private void initArcs(out GameObject[,] arcs, GameObject arc, int tileSize, float offset)
	{
		arcs = new GameObject[Screen.width / tileSize + 2, Screen.height / tileSize + 2];

		for (int i = 0; i < arcs.GetLength(0); i++)
		{
			for (int j = 0; j < arcs.GetLength(1); j++)
			{
				arcs[i,j] = Instantiate (arc, new Vector3(i * offset - (Screen.width / 64), j * offset - (Screen.height / 64), 0f), Quaternion.identity) as GameObject;
			}
		}
	}

	private void updatePosition(GameObject[,] toMove, float scrollSpeed, float offset)
	{
		for (int i = 0; i < toMove.GetLength(0); i++)
		{
			for (int j = 0; j < toMove.GetLength(1); j++)
			{
				Vector3 newPosition = toMove[i,j].transform.position + Vector3.up * scrollSpeed;
				if (newPosition.y > Screen.height / 64 + offset + 1)
				{
					newPosition.y = toMove[i, (j < toMove.GetLength(1) - 1 ? j : -1) + 1].transform.position.y - offset;
				}
				toMove[i,j].transform.position = newPosition;
			}
		}
	}
}