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
    private int DropChance = 5;

    [SerializeField]
    private GameObject ItemPrefab;

    public void DropItemCheck()
    {
        int RandomChance = Random.Range(1, 100);
        if (RandomChance < DropChance)
        {
            Instantiate(ItemPrefab, transform.position, Quaternion.identity);
        }
    }
}
