using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class ShopCardCategorys
{
    [SerializeField]
    private BuildingInformation[] towerInformation;

    public BuildingInformation[] TowerInformation
    {
        get { return towerInformation; }
        set { towerInformation = value; }
    }
    [SerializeField]
    private BuildingInformation[] wallInformation;

    public BuildingInformation[] WallInformation
    {
        get { return wallInformation; }
        set { wallInformation = value; }
    }

}
