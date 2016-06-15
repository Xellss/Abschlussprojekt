using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class SunClickBehaviour : MonoBehaviour, IPointerClickHandler {

    [SerializeField]
    private GameObject worldMap;
    public void OnPointerClick(PointerEventData eventData)
    {
        worldMap.SetActive(true);
    }
}
