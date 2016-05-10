/////////////////////////////////////////////////
///                                           ///
///      Source Code - Abschlussprojekt       ///
///                                           ///
///           Author: Julian Hopp             ///
///                                           ///
///                                           ///
/////////////////////////////////////////////////

using UnityEngine;

public class ItemRangeUp : MonoBehaviour
{
    private TowerController towerController;

    public void OnDisable()
    {
        towerController.Range -= 5;
    }

    public void OnEnable()
    {
        towerController.Range += 5;
    }

    private void Awake()
    {
        towerController = GetComponent<TowerController>();
    }
}
