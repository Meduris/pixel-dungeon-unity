using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleScreenBlueLines : MonoBehaviour
{
    public float alphaChange = -0.003f;
    public float minAlpha = 0f;
    public float maxAlpha = 1f;

    private bool invert;

    private Image img;

    // Use this for initialization
    void Start()
    {
        img = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (img.color.a <= minAlpha)
            invert = true;
        else if (img.color.a >= maxAlpha)
            invert = false;
        float newAlpha = img.color.a + (invert ? -alphaChange : alphaChange);
        img.color = new Color(img.color.r, img.color.g, img.color.b, newAlpha);
    }
}