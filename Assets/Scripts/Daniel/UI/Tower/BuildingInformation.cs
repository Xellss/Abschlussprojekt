/////////////////////////////////////////////////
///                                           ///
///      Source Code - Abschlussprojekt       ///
///                                           ///
///           Author: Daniel Lause            ///
///                                           ///
///                                           ///
/////////////////////////////////////////////////
using System;
using UnityEngine;

public enum BuildingTypes
{
    UpgradeBuilding,
    MainBuilding,
    Tower,
    Wall,
}

[Serializable]
public class BuildingInformation : ScriptableObject
{
    [SerializeField]
    private BuildingTypes buildingTypes;

    public BuildingTypes BuildingTypes
    {
        get { return buildingTypes; }
        set { buildingTypes = value; }
    }

    [SerializeField]
    private GameObject buildingPrefab;

    public GameObject BuildingPrefab
    {
        get { return buildingPrefab; }
        set { buildingPrefab = value; }
    }

    [SerializeField]
    private string buildingName;

    public string BuildingName
    {
        get { return buildingName; }
        set { buildingName = value; }
    }

    [SerializeField]
    private int buildingGoldAmount;

    public int BuildingGoldAmount
    {
        get { return buildingGoldAmount; }
        set { buildingGoldAmount = value; }
    }

    [SerializeField]
    private int buildingAmount;

    public int BuildingAmount
    {
        get { return buildingAmount; }
        set { buildingAmount = value; }
    }

}