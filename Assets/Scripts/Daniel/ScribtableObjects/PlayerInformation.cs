﻿/////////////////////////////////////////////////
///                                           ///
///      Source Code - Abschlussprojekt       ///
///                                           ///
///           Author: Daniel Lause            ///
///                                           ///
///                                           ///
/////////////////////////////////////////////////
using UnityEngine;

[SerializeField]
public class PlayerInformation : ScriptableObject
{
    [SerializeField]
    private int outpostGoldAmount;
    [SerializeField]
    private string playerName;

    [SerializeField]
    private int totalGoldAmount;

    public int OutpostGoldAmount
    {
        get { return outpostGoldAmount; }
        set { outpostGoldAmount = value; }
    }

    public string PlayerName
    {
        get { return playerName; }
        set { playerName = value; }
    }

    public int TotalGoldAmount
    {
        get { return totalGoldAmount; }
        set { totalGoldAmount = value; }
    }
}
