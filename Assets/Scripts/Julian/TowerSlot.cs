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

public class TowerSlot : MonoBehaviour
{
    [SerializeField]
    private TowerController towerPrefab;

    private Transform myTransform;
    private Renderer myRenderer;

    private bool hasTower = false;

    void Awake()
    {
        myTransform = GetComponent<Transform>();
        myRenderer = GetComponent<Renderer>();
    }

    void OnMouseEnter()
    {
        myRenderer.material.color = Color.red;
    }

    void OnMouseExit()
    {
        myRenderer.material.color = Color.green;
    }

    void OnMouseUp()
    {
        if (hasTower)
            return;

        if (LevelManager.Money < LevelManager.TowerPrice)
            return;

        LevelManager.Money -= LevelManager.TowerPrice;
        TowerController newTower = (TowerController)Instantiate(towerPrefab, myTransform.position, Quaternion.identity);
        newTower.transform.Translate(0, 2, 0);
        newTower.transform.SetParent(myTransform);
        hasTower = true;
    }
}
