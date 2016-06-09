using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class HideButtonOnClickOutside : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{

    private bool focus;

    public void OnPointerClick(PointerEventData eventData)
    {
        focus = false;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        focus = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        focus = false;
    }

    private void HideIfClickedOutside(GameObject panel)
    {
        if (Input.GetMouseButton(0) && panel.activeSelf &&
            !RectTransformUtility.RectangleContainsScreenPoint(
                panel.GetComponent<RectTransform>(),
                Input.mousePosition,
                Camera.main))
        {
            panel.SetActive(false);
        }
    }
    void Update()
    {
        if (!focus)
        {

        HideIfClickedOutside(this.gameObject);
        }
    }
}
