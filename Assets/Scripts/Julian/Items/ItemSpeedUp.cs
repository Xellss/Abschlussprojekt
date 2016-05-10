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

public class ItemSpeedUp : MonoBehaviour {

    private TowerController towerController;

    void Awake()
    {
        towerController = GetComponent<TowerController>();
    }

    public void OnEnable()
    {
        towerController.ShootDelay += 5;
    }

    public void OnDisable()
    {
        towerController.Range -= 5;
    }
}
