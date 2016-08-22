/////////////////////////////////////////////////
///                                           ///
///      Source Code - Abschlussprojekt       ///
///                                           ///
///           Author: Daniel Lause            ///
///                                           ///
///                                           ///
/////////////////////////////////////////////////
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragAndDropBuilding : MonoBehaviour, IDragHandler, IEndDragHandler, IPointerExitHandler
{
    private BuildingInformation buildingInfo;

    private bool click;

    public bool Click
    {
        get { return click; }
        set { click = value; }
    }

    private bool follow;
    private GameState gameState;
    private Text goldAmountText;
    private RaycastHit hit;
    private GameObject newBuilding;
    private GameObject newBuildingContainer;
    private RepairBuilding repairBuilding;
    private DestroyBuildedTower sellBuilding;
    private ShopCardCreator shopCardCreator;
    private GameObject starBase;
    private Tutorial tutorial;
    private Timer timer;

    public BuildingInformation BuildingInfo
    {
        get { return buildingInfo; }
        set { buildingInfo = value; }
    }

    public GameObject NewBuilding
    {
        get { return newBuilding; }
        set { newBuilding = value; }
    }



    public void OnDrag(PointerEventData eventData)
    {
        shopCardCreator.CanBuyBuilding();
        if (!click && gameState.GoldAmount >= buildingInfo.BuildingGoldCost)
        {
            print(gameState.GoldAmount + "    " + buildingInfo.BuildingGoldCost);
            if (tutorial != null)
            {
            tutorial.BuildInProgress = true;
            }
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

    public void OnEnable()
    {
        goldAmountText.text = gameState.GoldAmount.ToString();
        shopCardCreator.CanBuyBuilding();
        click = false;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        try
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
                            newBuilding.tag = "Tower";
                            //repairBuilding = newBuilding.GetComponent<RepairBuilding>();
                            //repairBuilding.BuildingInfo = buildingInfo;
                            //sellBuilding = collider.gameObject.transform.GetComponent<DestroyBuildedTower>();
                            //sellBuilding.BuildingInformation = buildingInfo;
                            //sellBuilding.enabled = true;
                            //newBuilding.GetComponent<BuildingHealth>().DestroyBuilding = sellBuilding;
                            //newBuilding.GetComponent<RepairBuilding>().DestroyBuilding = sellBuilding;

                            var direction = starBase.transform.position - newBuilding.transform.position;
                            direction.y = 0;
                            newBuilding.transform.rotation = Quaternion.LookRotation(-direction);

                            if (newBuilding.GetComponent<GoldTower>() != null)
                                newBuilding.GetComponent<GoldTower>().TowerActive = true;

                            if (tutorial != null)
                                tutorial.BuildTutClear = true;
                            return;
                        }
                    }
                }
            }
            if (click)
            GameObject.Destroy(newBuilding);
            click = false;
            if (tutorial != null)
            {
            tutorial.BuildInProgress = false;
            }
            return;
        }
        catch (MissingReferenceException)
        {
            return;
        }
        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        follow = false;
    }

    private void Awake()
    {
        gameState = (GameState)FindObjectOfType(typeof(GameState));
        if (gameState.gameObject.GetComponent<Tutorial>() != null)
        {
        tutorial = gameState.gameObject.GetComponent<Tutorial>();
            timer = gameState.gameObject.GetComponent<Timer>();
        }
        goldAmountText = GameObject.Find("GoldAmount").GetComponent<Text>();
        shopCardCreator = GameObject.Find("Canvas").GetComponent<ShopCardCreator>();
        newBuildingContainer = GameObject.Find("newBuildingContainer");
        starBase = GameObject.Find("SunSystem");
    }

    private void Update()
    {
        try
        {
         if (click)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(ray, out hit);
            if (hit.transform != null && newBuilding.activeInHierarchy)
            {
                newBuilding.transform.position = new Vector3(hit.point.x, 0, hit.point.z);
            }
        }
        }
        catch (MissingReferenceException)
        {
            return;
        }
    }
}
