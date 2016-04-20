using UnityEngine;
using System.Collections;
using System;

public enum towerTypes
{
    Tower,
    FireTower,
    IceTower,
    PoisenTower,
    SniperTower,
    DamageTower
}
[Serializable]
public class TowerInformation : ScriptableObject
{
    //[SerializeField]
    //private Text towerNameText;
    //[SerializeField]
    //private Text towerAmountText;

    [SerializeField]
    public towerTypes towerType;
    [SerializeField]
    private GameObject TowerPrefab;
    [SerializeField]
    private string towerName;
    [SerializeField]
    private int towerGoldAmount;

}