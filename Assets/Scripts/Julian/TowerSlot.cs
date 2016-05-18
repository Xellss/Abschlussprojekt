/////////////////////////////////////////////////
///                                           ///
///      Source Code - Abschlussprojekt       ///
///                                           ///
///           Author: Julian Hopp             ///
///                                           ///
///                                           ///
/////////////////////////////////////////////////

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class TowerSlot : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler, IPointerClickHandler
{
    private Text gold;
    private bool hasTower = false;
    private Renderer myRenderer;
    private Transform myTransform;
    [SerializeField]
    private TowerController towerPrefab;
    ShopButtonBehaviour shopButtonBehavior;

    private GameState gameState;

    private void Awake()
    {

        shopButtonBehavior = (ShopButtonBehaviour)FindObjectOfType(typeof(ShopButtonBehaviour));
        gameState = (GameState)FindObjectOfType(typeof(GameState));
        myTransform = GetComponent<Transform>();
        myRenderer = GetComponent<Renderer>();
        if (GameObject.Find("GoldAmountOutpost") != null)
        gold = GameObject.Find("GoldAmountOutpost").GetComponent<Text>();

    }
    void Start()
    {

    }

    public void OnPointerExit(PointerEventData eventData)
    {
            myRenderer.material.color = Color.green;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
            myRenderer.material.color = Color.cyan;
    }

   

    public void OnPointerClick(PointerEventData eventData)
    {
        if (hasTower)
            return;

        gameState.OutPostGoldAmount -= LevelManager.TowerPrice;
        shopButtonBehavior.OnTowerSlotClick(transform,this);

    }
}
