/////////////////////////////////////////////////
///                                           ///
///      Source Code - Abschlussprojekt       ///
///                                           ///
///           Author: Julian Hopp             ///
///                                           ///
///                                           ///
/////////////////////////////////////////////////

using UnityEngine;
using System.Collections;

public class ItemDrop : MonoBehaviour
{
    [SerializeField]
    private int LowItemDropChance = 5;
    [SerializeField]
    private GameObject LowItem;

    [SerializeField]
    private int MidItemDropChance = 3;
    [SerializeField]
    private GameObject MidItem;

    [SerializeField]
    private int HighItemDropChance = 2;
    [SerializeField]
    private GameObject HighItem;

    public void DropItemCheck()
    {
        int RandomChance = Random.Range(1, 100);
        if (RandomChance < HighItemDropChance)
        {
            Instantiate(HighItem, transform.position, Quaternion.identity);
            return;
        }
        if (RandomChance < MidItemDropChance)
        {
            Instantiate(MidItem, transform.position, Quaternion.identity);
            return;
        }
        if (RandomChance < LowItemDropChance)
        {
            Instantiate(LowItem, transform.position, Quaternion.identity);
            return;
        }
    }
}
