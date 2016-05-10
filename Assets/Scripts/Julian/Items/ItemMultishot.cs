/////////////////////////////////////////////////
///                                           ///
///      Source Code - Abschlussprojekt       ///
///                                           ///
///           Author: Julian Hopp             ///
///                                           ///
///                                           ///
/////////////////////////////////////////////////

using UnityEngine;

public class ItemMultishot : MonoBehaviour
{
    private TowerController towerController;

    public void OnDisable()
    {
        towerController.MultitargetingItem = false;
    }

    public void OnEnable()
    {
        towerController.MultitargetingItem = true;
    }

    private void Awake()
    {
        towerController = GetComponent<TowerController>();
    }
}
