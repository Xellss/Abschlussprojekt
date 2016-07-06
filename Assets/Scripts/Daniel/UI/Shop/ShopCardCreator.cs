/////////////////////////////////////////////////
///                                           ///
///      Source Code - Abschlussprojekt       ///
///                                           ///
///           Author: Daniel Lause            ///
///                                           ///
///                                           ///
/////////////////////////////////////////////////
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopCardCreator : MonoBehaviour
{
    [SerializeField]
    private GameObject buildButton;
    private Text buildingGoldCost;
    private Image buildingImage;
    [SerializeField]
    private Text buildingInformation;
    [SerializeField]
    private BuildingInformation[] buildingInfos;
    private Text buildingName;
    private BuildingSpawn buildingSpawn;
    private ShopButtonBehaviour buttonBehaviour;
    [SerializeField]
    private GameObject content;
    private BuildingInformation currentBuildingInformation;
    private GameState gameState;
    private GameObject newBuilding;
    [SerializeField]
    private Button shopCardBuildButton;
    private Button shopCardButton;
    private string shopCardMark = "ShopCard_";

    private Dictionary<GameObject, BuildingInformation> shopCards;

    public Text BuildingInformation
    {
        get { return buildingInformation; }
        set { buildingInformation = value; }
    }

    public void CanBuyBuilding()
    {
        foreach (var shopCard in shopCards)
        {
            if (shopCard.Value.BuildingGoldCost > gameState.GoldAmount)
            {
                shopCard.Key.GetComponent<Image>().color = Color.red;
            }
            else
            {
                shopCard.Key.GetComponent<Image>().color = Color.white;
            }
        }
    }

    private void Awake()
    {
        gameState = (GameState)FindObjectOfType(typeof(GameState));

        buildingSpawn = gameObject.GetComponent<BuildingSpawn>();
        buttonBehaviour = gameObject.GetComponent<ShopButtonBehaviour>();
        shopCards = new Dictionary<GameObject, BuildingInformation>();
    }

    private void createShopCards()
    {
        foreach (var buildingInfo in buildingInfos)
        {
            GameObject shopCard = (GameObject)Instantiate(Resources.Load("Prefabs/BuildingShopCard"));
            shopCard.transform.SetParent(content.transform, false);
            shopCard.name = shopCardMark + buildingInfo.BuildingName;
            editShopCard(shopCard, buildingInfo);
            shopCards.Add(shopCard, buildingInfo);
        }
    }

    private void editShopCard(GameObject currentShopCard, BuildingInformation cardInformation)
    {
        shopCardButton = currentShopCard.GetComponent<Button>();
        buildingImage = currentShopCard.transform.FindChild("BuildingImage").GetComponent<Image>();
        buildingName = currentShopCard.transform.FindChild("BuildingName").GetComponent<Text>();
        buildingGoldCost = currentShopCard.transform.FindChild("BuildingGoldCost").GetComponent<Text>();

        shopCardButton.onClick.AddListener(delegate () { buttonBehaviour.OnClickShopCard(buildingSpawn, cardInformation, buildButton, buildingInformation, shopCardBuildButton); });
        buildingImage.sprite = cardInformation.BuildingImage;
        buildingName.text = cardInformation.BuildingName;
        buildingGoldCost.text = cardInformation.BuildingGoldCost.ToString();
    }

    private void Start()
    {
        createShopCards();
    }
}
