/////////////////////////////////////////////////
///                                           ///
///      Source Code - Abschlussprojekt       ///
///                                           ///
///           Author: Daniel Lause            ///
///                                           ///
///                                           ///
/////////////////////////////////////////////////
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RepairBuilding : MonoBehaviour, IPointerClickHandler
{
    private BuildingInformation buildingInfo;
    private DestroyBuildedTower destroyBuilding;
    public DestroyBuildedTower DestroyBuilding
    {
        get { return destroyBuilding; }
        set { destroyBuilding = value; }
    }

    private GameState gamestate;
    private BuildingHealth health;
    private Renderer[] renderer;
    private bool repair = false;
    private TowerController towerController;
    private BombTower bombTower;
    private ShopCardCreator shopCardCreator;

    public BuildingInformation BuildingInfo
    {
        get { return buildingInfo; }
        set { buildingInfo = value; }
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

    private void repairBuilding()
    {
        if ((buildingInfo.RepairAmount <= gamestate.GoldAmount) && !repair)
        {
            repair = true;
            gamestate.GoldAmount -= buildingInfo.RepairAmount;
            shopCardCreator.CanBuyBuilding();
            destroyBuilding.SellTowerButtonGameObject.SetActive(false);

            //StartCoroutine(repairTime(buildingInfo.RepairTime));
            StartCoroutine(repairTime(0));
        }
        else
        {
            destroyBuilding.SellTowerButtonGameObject.SetActive(false);
        }
    }

    private IEnumerator repairTime(float time)
    {
        yield return new WaitForSeconds(time);
        health.AddHealth(health.MaxHealth);
        destroyBuilding.enabled = true;

        if (renderer != null)
        {
            if (renderer.Length > 0)
            {
                for (int i = 0; i < renderer.Length; i++)
                {
                    renderer[i].material.color = Color.white;
                }
            }
        }
        else
            GetComponentInChildren<MeshRenderer>().material.color = Color.white;

        gameObject.tag = "Building";

        if (health.LookAtEnemy != null)
        {
            health.LookAtEnemy.LookActive = true;
            health.LookAtEnemy.StartLookAt();
        }
        if (towerController != null)
        {
            towerController.CanShoot = true;
        }
        if (bombTower != null)
        {
            bombTower.CanShoot = true;
        }
        repair = false;
    }

    private void Start()
    {
        shopCardCreator = GameObject.Find("Canvas").GetComponent<ShopCardCreator>();
        health = GetComponent<BuildingHealth>();
        gamestate = GameObject.Find("GlobalScripts").GetComponent<GameState>();
        destroyBuilding = GetComponentInParent<DestroyBuildedTower>();
        towerController = GetComponentInParent<TowerController>();
        bombTower = GetComponentInParent<BombTower>();
        renderer = GetComponentsInChildren<Renderer>();
    }
}
