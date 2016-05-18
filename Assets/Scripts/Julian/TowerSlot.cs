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

public class TowerSlot : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler, IPointerClickHandler, IPointerUpHandler
{
    private Text gold;
    private bool hasTower = false;
    private Renderer myRenderer;
    private Transform myTransform;
    [SerializeField]
    private TowerController towerPrefab;
    ShopButtonBehaviour shopButtonBehavior;
    GameObject ground;
    private GameState gameState;

    private void Awake()
    {
        ground = GameObject.Find("Ground");
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
        ground.layer = LayerMask.NameToLayer("Default");
        shopButtonBehavior.OnTowerSlotClick(transform,this);

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        ground.layer = LayerMask.NameToLayer("Ground");
    }
}
