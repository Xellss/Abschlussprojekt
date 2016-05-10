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

public class ItemMultishot : MonoBehaviour {

    private TowerController towerController;

    void Awake()
    {
        towerController = GetComponent<TowerController>();
    }

    public void OnEnable()
    {
        towerController.MultitargetingItem = true;
    }

    public void OnDisable()
    {
        towerController.MultitargetingItem = false;
    }
}
