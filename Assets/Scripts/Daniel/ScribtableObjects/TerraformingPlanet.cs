﻿/////////////////////////////////////////////////
///                                           ///
///      Source Code - Abschlussprojekt       ///
///                                           ///
///           Author: Daniel Lause            ///
///                                           ///
///                                           ///
/////////////////////////////////////////////////
using System;
using UnityEngine;

[Serializable]
public class TerraformingPlanet : ScriptableObject
{
    [SerializeField]
    public int GasPlanetChanceInPercent;
    [SerializeField]
    public int GasPlanetGoldBonus;
    [SerializeField]
    public PoolPrefab[] RegularPlanetPrefabs;
    [SerializeField]
    public PoolPrefab[] GasPlanetPrefabs;
}
