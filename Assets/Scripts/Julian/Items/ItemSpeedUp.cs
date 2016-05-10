/////////////////////////////////////////////////
///                                           ///
///      Source Code - Abschlussprojekt       ///
///                                           ///
///           Author: Julian Hopp             ///
///                                           ///
///                                           ///
/////////////////////////////////////////////////

using UnityEngine;

public class ItemSpeedUp : MonoBehaviour
{
    private TowerController towerController;

    public void OnDisable()
    {
        towerController.Range -= 5;
    }

    public void OnEnable()
    {
        towerController.ShootDelay += 5;
    }

    private void Awake()
    {
        towerController = GetComponent<TowerController>();
    }
}
