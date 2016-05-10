/////////////////////////////////////////////////
///                                           ///
///      Source Code - Abschlussprojekt       ///
///                                           ///
///           Author: Julian Hopp             ///
///                                           ///
///                                           ///
/////////////////////////////////////////////////

using UnityEngine;
using UnityEngine.UI;

public class TowerSlot : MonoBehaviour
{
    private Text gold;
    private bool hasTower = false;
    private Renderer myRenderer;
    private Transform myTransform;
    [SerializeField]
    private TowerController towerPrefab;

    private void Awake()
    {
        myTransform = GetComponent<Transform>();
        myRenderer = GetComponent<Renderer>();
        gold = GameObject.Find("GoldAmount").GetComponent<Text>();
    }

    private void OnMouseEnter()
    {
        myRenderer.material.color = Color.red;
    }

    private void OnMouseExit()
    {
        myRenderer.material.color = Color.green;
    }

    private void OnMouseUp()
    {
        if (hasTower)
            return;

        if (LevelManager.Money < LevelManager.TowerPrice)
            return;

        LevelManager.Money -= LevelManager.TowerPrice;
        gold.text = LevelManager.Money.ToString();
        TowerController newTower = (TowerController)Instantiate(towerPrefab, myTransform.position, Quaternion.identity);
        newTower.transform.Translate(0, 2, 0);
        newTower.transform.SetParent(myTransform);
        hasTower = true;
    }
}
