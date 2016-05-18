/////////////////////////////////////////////////
///                                           ///
///      Source Code - Abschlussprojekt       ///
///                                           ///
///           Author: Daniel Lause            ///
///                                           ///
///                                           ///
/////////////////////////////////////////////////
using UnityEngine;
using UnityEngine.UI;

public class ShopButtonBehaviour : MonoBehaviour
{
    private BuildingInformation buildingCardInformation;
    private Text buildingInformationText;
    private BuildingSpawn buildingSpawn;
    private ShopCardCreator cardCreator;
    private GameState gameState;
    [SerializeField]
    private Text goldAmount;
    private GameObject Ground;
    [SerializeField]
    private GameObject newBuilding;
    private GameObject shop;
    [SerializeField]
    private GameObject shopBuildButton;
    [SerializeField]
    private Text shopGoldAmount;
    private TowerSlot towerSlotScript;
    private Transform towerSlotTransform;

    public void OnClickGiveGold()
    {
        gameState.GoldAmount += 5000;
        goldAmount.text = gameState.GoldAmount.ToString();
    }

    public void OnClickShopCard(BuildingSpawn buildingSpawn, BuildingInformation cardInformation, GameObject buildButton, Text buildingInformation, Button shopCardBuildButton)
    {
        this.buildingSpawn = buildingSpawn;

        if (cardInformation != null)
        {
            buildingInformation.text = cardInformation.BuildingInformationText.ToString();
            this.buildingCardInformation = cardInformation;
            shopBuildButton.SetActive(true);
            if (gameState.GoldAmount >= cardInformation.BuildingGoldCost)
            {
                shopBuildButton.GetComponent<Button>().interactable = true;
            }
            else
            {
                shopBuildButton.GetComponent<Button>().interactable = false;
            }
        }
    }

    public void OnClickShopCardBuild()
    {
        gameState.GoldAmount -= buildingCardInformation.BuildingGoldCost;
        goldAmount.text = gameState.GoldAmount.ToString();
        shop.SetActive(false);
        newBuilding = (GameObject)Instantiate(buildingCardInformation.BuildingPrefab, towerSlotTransform.position, Quaternion.identity);
        newBuilding.layer = LayerMask.NameToLayer(buildingCardInformation.BuildingTypes.ToString());
        newBuilding.name = buildingCardInformation.BuildingName;
        newBuilding.transform.SetParent(towerSlotTransform);
        towerSlotScript.enabled = false;
        newBuilding.tag = "Building";
        buildingSpawn.BuildingPrefab = newBuilding;
        buildingSpawn.BuildingInformation = buildingCardInformation;
        Ground.layer = LayerMask.NameToLayer("Ground");
    }

    public void OnShopCloseClick()
    {
        shop.SetActive(false);
        Ground.layer = LayerMask.NameToLayer("Ground");
    }

    public void OnTowerSlotClick(Transform slotPosition, TowerSlot towerSlotScript)
    {
        this.towerSlotScript = towerSlotScript;
        this.towerSlotTransform = slotPosition;
        shopGoldAmount.text = gameState.GoldAmount.ToString();
        cardCreator.CanBuyBuilding();
        shopBuildButton.SetActive(false);
        buildingInformationText.text = "Wähle eine Shop Karte aus, um Informationen zu erhalten oder dieses Gebäude zu bauen.";
        shop.SetActive(true);
    }

    private void Awake()
    {
        gameState = (GameState)FindObjectOfType(typeof(GameState));
        gameObject.GetComponent<BuildingSpawn>();
        shop = transform.FindChild("Shop").gameObject;
        cardCreator = GetComponent<ShopCardCreator>();
        buildingInformationText = cardCreator.BuildingInformation;
        goldAmount.text = gameState.GoldAmount.ToString();
        Ground = GameObject.Find("Ground");
    }
}
