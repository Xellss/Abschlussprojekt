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

public class TowerSlotSpawner : MonoBehaviour
{
    [SerializeField]
    private Transform TowerSlot;

    public float Hight = 30;
    public float Length = 30;
    public float Width = 30;

    void Start()
    {
        for (int x = 0; x < Width; x++)
        {
            for (int z = 0; z < Length; z++)
            {
                Instantiate(TowerSlot, new Vector3(x, Hight, z), Quaternion.identity);
            }
        }

    }
}
