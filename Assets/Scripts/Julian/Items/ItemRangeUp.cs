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

public class ItemRangeUp : MonoBehaviour
{
    private TowerController towerController;

    void Awake()
    {
        towerController = GetComponent<TowerController>();
    }

    public void OnEnable()
    {
        towerController.Range += 5;
    }

    public void OnDisable()
    {
        towerController.Range -= 5;
    }
}
