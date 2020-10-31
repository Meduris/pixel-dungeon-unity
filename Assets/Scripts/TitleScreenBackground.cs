using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreenBackground : MonoBehaviour
{
    public float scrollSpeedSmall;
    public float scrollSpeedBig;

    public GameObject bigPrefab;
    public GameObject smallPrefab;

    private Vector3 startPos_upper;
    private Vector3 startPos_lower;

    private Vector2 spriteSize;

    private float worldScreenHeight;
    private float worldScreenWidth;

    private GameObject big1;
    private GameObject big2;
    private GameObject small1;
    private GameObject small2;

    void Start()
    {
        worldScreenHeight = Camera.main.orthographicSize * 2.0f;
        worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;

        spriteSize = new Vector2(worldScreenWidth * .32f + .32f, worldScreenHeight * .32f + .32f);

        startPos_upper = new Vector3(0.0f, 0.0f, 0.0f);
        startPos_lower = startPos_upper + (worldScreenHeight + .56f) * Vector3.down;

        InstantiatePrefab(bigPrefab, out big1, startPos_upper);
        InstantiatePrefab(bigPrefab, out big2, startPos_lower);
        InstantiatePrefab(smallPrefab, out small1, startPos_upper);
        InstantiatePrefab(smallPrefab, out small2, startPos_lower);
    }

    void Update()
    {
        float newPosSmall = Mathf.Repeat(Time.time * scrollSpeedSmall, worldScreenHeight + .56f);
        float newPosBig = Mathf.Repeat(Time.time * scrollSpeedBig, worldScreenHeight + .56f);
        big1.transform.position = startPos_upper + newPosBig * Vector3.up;
        big2.transform.position = startPos_lower + newPosBig * Vector3.up;
        small1.transform.position = startPos_upper + newPosSmall * Vector3.up;
        small2.transform.position = startPos_lower + newPosSmall * Vector3.up;
    }

    private void InstantiatePrefab(GameObject prefab, out GameObject target, Vector3 position)
    {
        target = Instantiate(prefab, position, Quaternion.identity) as GameObject;
        target.GetComponent<SpriteRenderer>().size = spriteSize;
        target.transform.SetParent(gameObject.transform);
    }
}