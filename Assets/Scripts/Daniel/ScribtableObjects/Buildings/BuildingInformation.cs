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
    private int buildingAmount;
    [SerializeField]
    private int buildingGoldCost;
    [SerializeField]
    private Sprite buildingImage;
    [SerializeField, TextArea]
    private string buildingInformationText;
    [SerializeField]
    private string buildingName;
    [SerializeField]
    private GameObject buildingPrefab;
    [SerializeField]
    private BuildingTypes buildingTypes;

    public int BuildingAmount
    {
        get { return buildingAmount; }
        set { buildingAmount = value; }
    }

    public int BuildingGoldCost
    {
        get { return buildingGoldCost; }
        set { buildingGoldCost = value; }
    }

    public Sprite BuildingImage
    {
        get { return buildingImage; }
        set { buildingImage = value; }
    }

    public string BuildingInformationText
    {
        get { return buildingInformationText; }
        set { buildingInformationText = value; }
    }

    public string BuildingName
    {
        get { return buildingName; }
        set { buildingName = value; }
    }

    public GameObject BuildingPrefab
    {
        get { return buildingPrefab; }
        set { buildingPrefab = value; }
    }

    public BuildingTypes BuildingTypes
    {
        get { return buildingTypes; }
        set { buildingTypes = value; }
    }
}
