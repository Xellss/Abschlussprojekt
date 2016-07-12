using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;
using UnityEngine.UI;

public class RepairBuilding : MonoBehaviour, IPointerClickHandler
{
    GameState gamestate;
    Renderer renderer;
    DestroyBuildedTower destroyBuilding;
    TowerController towerController;
    Text goldAmount;
    BuildingHealth health;
    bool repair = false;
    private BuildingInformation buildingInfo;

    public BuildingInformation BuildingInfo
    {
        get { return buildingInfo; }
        set { buildingInfo = value; }
    }


    private void Start()
    {
        health = GetComponent<BuildingHealth>();
        gamestate = GameObject.Find("GlobalScripts").GetComponent<GameState>();
        destroyBuilding = GetComponentInParent<DestroyBuildedTower>();
        towerController = GetComponentInParent<TowerController>();
        goldAmount = GameObject.Find("GoldAmount").GetComponent<Text>();
        renderer = GetComponent<Renderer>();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (this.gameObject.tag == "Destroyed" && !repair)
        {
            destroyBuilding.SellButtonText.text = string.Format("{0}{1}{2}{3}", buildingInfo.BuildingName, " für ", buildingInfo.RepairAmount, " reparieren.");
            destroyBuilding.SellTowerButtonGameObject.SetActive(true);
            destroyBuilding.SellTowerButton.onClick.RemoveAllListeners();
            destroyBuilding.SellTowerButton.onClick.AddListener(delegate { repairBuilding(); });
        }
    }
    void repairBuilding()
    {
        if ((buildingInfo.RepairAmount <= gamestate.GoldAmount) && !repair)
        {
            repair = true;
            gamestate.GoldAmount -= buildingInfo.RepairAmount;
            goldAmount.text = gamestate.GoldAmount.ToString();
            destroyBuilding.SellTowerButtonGameObject.SetActive(false);
            StartCoroutine(repairTime(buildingInfo.RepairTime));
        }
        else
        {
            destroyBuilding.SellTowerButtonGameObject.SetActive(false);
        }
    }

    IEnumerator repairTime(float time)
    {
        yield return new WaitForSeconds(time);
        health.AddHealth(health.MaxHealth);
        destroyBuilding.enabled = true;
        if (renderer != null)
        {
            renderer.material.color = Color.white;

        }
        else
            GetComponentInChildren<MeshRenderer>().material.color = Color.white;

        gameObject.tag = "Building";


        if (health.LookAtEnemy!= null)
        {
            health.LookAtEnemy.LookActive = true;
            health.LookAtEnemy.StartLookAt();
        }
        if (towerController != null)
        {
            towerController.CanShoot = true;
        }
        repair = false;
    }
}
