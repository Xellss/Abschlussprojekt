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

public class DestroyBuildedTower : MonoBehaviour, IPointerClickHandler
{
    private BuildingInformation buildingInformation;
    private Transform[] buildings;
    private GameState gamestate;
    private Text sellButtonText;
    private Button sellTowerButton;
    [SerializeField]
    private GameObject sellTowerButtonGameObject;
    private ShopCardCreator shopCardCreator;
    private TowerSlot towerSlot;

    public BuildingInformation BuildingInformation
    {
        get { return buildingInformation; }
        set { buildingInformation = value; }
    }

    public Text SellButtonText
    {
        get { return sellButtonText; }
        set { sellButtonText = value; }
    }

    public Button SellTowerButton
    {
        get { return sellTowerButton; }
        set { sellTowerButton = value; }
    }

    public GameObject SellTowerButtonGameObject
    {
        get { return sellTowerButtonGameObject; }
        set { sellTowerButtonGameObject = value; }
    }

    public void OnClickSellBuilding()
    {
        gamestate.GoldAmount += buildingInformation.BuildingSellPrice;
        shopCardCreator.CanBuyBuilding();
        GameObject.Destroy(transform.GetChild(2).gameObject);
        towerSlot.enabled = true;
        towerSlot.BuildingOnSlot = false;
        sellTowerButtonGameObject.SetActive(false);
        this.enabled = false;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (buildingInformation != null)
        {
            sellButtonText.text = string.Format("{0}{1}{2}{3}", buildingInformation.BuildingName, " für ", buildingInformation.BuildingSellPrice, " verkaufen.");
            sellTowerButtonGameObject.SetActive(true);
            sellTowerButton.onClick.RemoveAllListeners();
            sellTowerButton.onClick.AddListener(delegate { OnClickSellBuilding(); });
        }
    }

    private void Start()
    {
        shopCardCreator = GameObject.Find("Canvas").GetComponent<ShopCardCreator>();
        gamestate = (GameState)FindObjectOfType(typeof(GameState));
        towerSlot = GetComponent<TowerSlot>();
        sellTowerButton = sellTowerButtonGameObject.GetComponent<Button>();
        
        sellButtonText = sellTowerButtonGameObject.transform.FindChild("Text").GetComponent<Text>();
    }
}
