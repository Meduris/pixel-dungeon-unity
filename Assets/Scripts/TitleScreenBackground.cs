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

	private GameObject[,] big_arcs;
	private GameObject[,] small_arcs;

	void Start () {
		initArcs(out small_arcs, arc_small, tileSizeSmall, smallOffset);
		initArcs(out big_arcs, arc_big, tileSizeBig, bigOffset);
	}
	
	// Update is called once per frame
	void Update () {
		updatePosition(small_arcs, scrollSpeedSmall, smallOffset);
		updatePosition(big_arcs, scrollSpeedBig, bigOffset);
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