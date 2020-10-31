using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HidePopupWindow : MonoBehaviour, IPointerExitHandler, IPointerEnterHandler
{
    private bool hasFocus = false;

    public void Update()
    {
        if (!hasFocus && Input.GetMouseButtonUp(0))
        {
            gameObject.SetActive(false);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        hasFocus = false;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        hasFocus = true;
    }
}