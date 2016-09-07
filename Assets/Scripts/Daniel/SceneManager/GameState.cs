/////////////////////////////////////////////////
///                                           ///
///      Source Code - Abschlussprojekt       ///
///                                           ///
///           Author: Daniel Lause            ///
///                                           ///
///                                           ///
/////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class GameState : MonoBehaviour
{
    Text goldAmountText = null;
    Animator goldAnimator = null;
    [SerializeField]
    private List<BuildingModel> buildings;
    [SerializeField]
    private int goldAmount;
    [SerializeField]
    private GameObject loseScreen;
    [SerializeField]
    private int outPostGoldAmount;
    [SerializeField]
    private string playerName;
    [SerializeField]
    private List<TerrainModel> terrains;

    public List<BuildingModel> Buildings
    {
        get { return buildings; }
        set { buildings = value; }
    }

    public int GoldAmount
    {
        get { return goldAmount; }
        set
        {
            if (value != goldAmount)
            {
                goldAmount = value;
                goldAmountText.text = goldAmount.ToString();
                goldAnimator.SetTrigger("GoldEffect");
            }

        }
    }

    public GameObject LoseScreen
    {
        get { return loseScreen; }
        set { loseScreen = value; }
    }

    public int OutPostGoldAmount
    {
        get { return outPostGoldAmount; }
        set { outPostGoldAmount = value; }
    }

    public string PlayerName
    {
        get { return playerName; }
        set { playerName = value; }
    }

    public List<TerrainModel> Terrains
    {
        get { return terrains; }
        set { terrains = value; }
    }

    private void Awake()
    {
        buildings = new List<BuildingModel>();
        //loseScreen.SetActive(false);
        goldAmountText = GameObject.Find("GoldAmount").GetComponent<Text>();
        goldAnimator = GameObject.Find("Unitys").GetComponent<Animator>();
        Time.timeScale = 1;
    }

    private void Update()
    {
        if (goldAmount < 0)
        {
            goldAmount = 0;
        }
    }
}
