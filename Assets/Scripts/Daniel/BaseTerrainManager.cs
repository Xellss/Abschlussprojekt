﻿/////////////////////////////////////////////////
///                                           ///
///      Source Code - Abschlussprojekt       ///
///                                           ///
///           Author: Daniel Lause            ///
///                                           ///
///                                           ///
/////////////////////////////////////////////////
/////////////////////////////////////////////////
/////////////////////////////////////////////////
///                                           ///
///      Source Code - Abschlussprojekt       ///
///                                           ///
///           Author: Daniel Lause            ///
///                                           ///
///                                           ///
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BaseTerrainManager : MonoBehaviour
{
    private BuyButton buyButton;
    private GameState gameState;
    private Text goldAmount;
    private Renderer renderer;
    [SerializeField]
    private int terrainGoldCost = 500;
    private TowerSlot towerSlot;
    [SerializeField]
    private bool unlock;

    public void UnlockTerrain()
    {
        if (unlock || gameState.GoldAmount >= terrainGoldCost)
        {
            if (!unlock)
            {
                gameState.GoldAmount -= terrainGoldCost;
                goldAmount.text = gameState.GoldAmount.ToString();
            }
            towerSlot.enabled = true;
            gameObject.name = "UnlockedTerrain";
            gameObject.tag = "UnlockedTerrain";
            buyButton.DestroyAsteroids(unlock);
            GameObject.Destroy(buyButton.gameObject);
            Component.Destroy(this);
        }
    }

    private void Awake()
    {
        goldAmount = GameObject.Find("GoldAmount").GetComponent<Text>();
        towerSlot = GetComponent<TowerSlot>();
        buyButton = transform.FindChild("BuyButton").GetComponent<BuyButton>();
        //renderer = gameObject.GetComponent<Renderer>();
        gameState = (GameState)FindObjectOfType(typeof(GameState));
    }

    private void Start()
    {
        StartCoroutine(unlockTimer());
    }

    private IEnumerator unlockTimer()
    {
        yield return new WaitForEndOfFrame();
        if (unlock)
            UnlockTerrain();
    }
}
