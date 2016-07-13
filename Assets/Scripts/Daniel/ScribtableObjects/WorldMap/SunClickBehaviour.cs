﻿/////////////////////////////////////////////////
///                                           ///
///      Source Code - Abschlussprojekt       ///
///                                           ///
///           Author: Daniel Lause            ///
///                                           ///
///                                           ///
/////////////////////////////////////////////////
using UnityEngine;
using UnityEngine.EventSystems;

public class SunClickBehaviour : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    private GameObject worldMap;

    public void OnPointerClick(PointerEventData eventData)
    {
        worldMap.SetActive(true);
    }
}
