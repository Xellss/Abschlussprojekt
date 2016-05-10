using UnityEngine;
using System.Collections;

[SerializeField]
public class PlayerInformation : ScriptableObject {

    [SerializeField]
    private string playerName;

    public string PlayerName
    {
        get { return playerName; }
        set { playerName = value; }
    }
    [SerializeField]
    private int totalGoldAmount;

    public int TotalGoldAmount
    {
        get { return totalGoldAmount; }
        set { totalGoldAmount = value; }
    }

    [SerializeField]
    private int outpostGoldAmount;

    public int OutpostGoldAmount
    {
        get { return outpostGoldAmount; }
        set { outpostGoldAmount = value; }
    }


}
