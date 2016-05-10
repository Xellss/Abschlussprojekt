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
using UnityEngine.UI;

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
    private Sprite buildingImage;

    public Sprite BuildingImage
    {
        get { return buildingImage; }
        set { buildingImage = value; }
    }

    [SerializeField]
    private string buildingName;

    public string BuildingName
    {
        get { return buildingName; }
        set { buildingName = value; }
    }

    [SerializeField]
    private int buildingGoldCost;

    public int BuildingGoldCost
    {
        get { return buildingGoldCost; }
        set { buildingGoldCost = value; }
    }

    [SerializeField]
    private int buildingAmount;

    public int BuildingAmount
    {
        get { return buildingAmount; }
        set { buildingAmount = value; }
    }

    [SerializeField,TextArea]
    private string buildingInformationText;

    public string BuildingInformationText
    {
        get { return buildingInformationText; }
        set { buildingInformationText = value; }
    }

}