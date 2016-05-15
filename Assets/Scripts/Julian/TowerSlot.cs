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

public class TowerSlot : MonoBehaviour
{
    private Text gold;
    private bool hasTower = false;
    private Renderer myRenderer;
    private Transform myTransform;
    [SerializeField]
    private TowerController towerPrefab;

    private GameState gameState;

    private void Awake()
    {
        gameState = (GameState)FindObjectOfType(typeof(GameState));
        myTransform = GetComponent<Transform>();
        myRenderer = GetComponent<Renderer>();
        if (GameObject.Find("GoldAmountOutpost") != null)
        gold = GameObject.Find("GoldAmountOutpost").GetComponent<Text>();

    }

    private void OnMouseEnter()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            myRenderer.material.color = Color.red;

        }
    }

    private void OnMouseExit()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            myRenderer.material.color = Color.green;
        }
    }

    private void OnMouseUp()
    {
        if (hasTower)
            return;

        if (gameState.OutPostGoldAmount < LevelManager.TowerPrice)
            return;

        if (!EventSystem.current.IsPointerOverGameObject())
        {
            gameState.OutPostGoldAmount -= LevelManager.TowerPrice;

            gold.text = gameState.OutPostGoldAmount.ToString();
            TowerController newTower = (TowerController)Instantiate(towerPrefab, myTransform.position, Quaternion.identity);
            newTower.transform.Translate(0, 2, 0);
            newTower.transform.SetParent(myTransform);
            hasTower = true;
        }
    }
}
