using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;
using UnityEngine.UI;

public class DragAndDropBuilding : MonoBehaviour, IDragHandler, IEndDragHandler, IPointerExitHandler
{
    private BuildingInformation buildingInfo;

    public BuildingInformation BuildingInfo
    {
        get { return buildingInfo; }
        set { buildingInfo = value; }
    }

    private GameObject newBuilding;

    public GameObject NewBuilding
    {
        get { return newBuilding; }
        set { newBuilding = value; }
    }


    bool click;
    private bool follow;
    private RaycastHit hit;
    private RepairBuilding repairBuilding;
    DestroyBuildedTower sellBuilding;

    GameObject newBuildingContainer;
    private GameState gameState;
    private Text goldAmountText;
    private ShopCardCreator shopCardCreator;

    void Awake()
    {
        gameState = (GameState)FindObjectOfType(typeof(GameState));
        goldAmountText = GameObject.Find("GoldAmount").GetComponent<Text>();
        shopCardCreator = GameObject.Find("Canvas").GetComponent<ShopCardCreator>();
        newBuildingContainer = GameObject.Find("newBuildingContainer");
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!click && gameState.GoldAmount >= buildingInfo.BuildingGoldCost)
        {

            click = true;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(ray, out hit);
            if (hit.transform != null)
            {

                newBuilding = (GameObject)Instantiate(buildingInfo.BuildingPrefab, new Vector3(hit.point.x, 0, hit.point.z), Quaternion.identity);
                newBuilding.transform.SetParent(newBuildingContainer.transform);
            }
            newBuilding.name = buildingInfo.BuildingName;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        follow = false;
    }

    void Update()
    {
        if (click)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(ray, out hit);
            if (hit.transform != null)
            {
                newBuilding.transform.position = new Vector3(hit.point.x, 0, hit.point.z);
            }
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (click)
        {

            Collider[] colliders = Physics.OverlapSphere(newBuilding.transform.position, 1);

            foreach (var collider in colliders)
            {
                if (collider.CompareTag("UnlockedTerrain"))
                {
                    TowerSlot slotScript = collider.gameObject.transform.GetComponent<TowerSlot>();
                    if (!slotScript.BuildingOnSlot)
                    {
                        click = false;
                        newBuilding.transform.position = collider.gameObject.transform.position;
                        newBuilding.transform.SetParent(collider.gameObject.transform);
                        slotScript.BuildingOnSlot = true;

                        gameState.GoldAmount -= buildingInfo.BuildingGoldCost;
                        goldAmountText.text = gameState.GoldAmount.ToString();
                        shopCardCreator.CanBuyBuilding();
                        newBuilding.layer = LayerMask.NameToLayer(buildingInfo.BuildingTypes.ToString());
                        newBuilding.tag = "Building";
                        repairBuilding = newBuilding.GetComponent<RepairBuilding>();
                        repairBuilding.BuildingInfo = buildingInfo;
                        sellBuilding = collider.gameObject.transform.GetComponent<DestroyBuildedTower>();
                        sellBuilding.BuildingInformation = buildingInfo;
                        sellBuilding.enabled = true;
                        newBuilding.GetComponent<BuildingHealth>().DestroyBuilding = sellBuilding;
                        newBuilding.GetComponent<RepairBuilding>().DestroyBuilding = sellBuilding;

                        return;
                    }
                }
            }

        }
        click = false;
        GameObject.Destroy(newBuilding);
        return;

    }

    public void OnEnable()
    {
        goldAmountText.text = gameState.GoldAmount.ToString();
        shopCardCreator.CanBuyBuilding();
    }
}
