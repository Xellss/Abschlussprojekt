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
        myRenderer.material.color = Color.white;
    }

    void OnMouseUp()
    {
        if (hasTower)
            return;

        if (LevelManager.Money < LevelManager.TowerPrice)
            return;

        TowerController newTower = (TowerController)Instantiate(towerPrefab, myTransform.position, Quaternion.identity);
        newTower.transform.SetParent(myTransform);
        hasTower = true;
    }
}
