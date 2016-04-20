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

public class ShopCardCreator : MonoBehaviour
{
    [SerializeField]
    private GameObject content;

    [SerializeField]
    private BuildingInformation[] buildingInfos;

    private GameObject newBuilding;
    private Button buildingButton;
    private Image buildingImage;
    private Text buildingName;
    private Text buildingGoldCost;
    private string shopCardMark = "ShopCard_";

    private BuildingSpawn buildingSpawn;

    private void Awake()
    {
        buildingSpawn = gameObject.GetComponent<BuildingSpawn>();
    }

    private void Start()
    {
        createShopCards();
    }

    private void createShopCards()
    {
        foreach (var buildingInfo in buildingInfos)
        {
            GameObject shopCard = (GameObject)Instantiate(Resources.Load("Prefabs/BuildingShopCard"));
            shopCard.transform.SetParent(content.transform);
            shopCard.name = shopCardMark + buildingInfo.BuildingName;
            editShopCard(shopCard, buildingInfo);
        }
    }

    private void editShopCard(GameObject currentShopCard, BuildingInformation cardInformation)
    {
        buildingButton = currentShopCard.GetComponent<Button>();
        buildingImage = currentShopCard.transform.FindChild("BuildingImage").GetComponent<Image>();
        buildingName = currentShopCard.transform.FindChild("BuildingName").GetComponent<Text>();
        buildingGoldCost = currentShopCard.transform.FindChild("BuildingGoldCost").GetComponent<Text>();

        buildingButton.onClick.AddListener(delegate () { OnClickShopCard(cardInformation); });
        buildingImage.sprite = cardInformation.BuildingImage;
        buildingName.text = cardInformation.BuildingName;
        buildingGoldCost.text = cardInformation.BuildingGoldCost.ToString();
    }

    private void OnClickShopCard(BuildingInformation cardInformation)
    {
        transform.GetChild(0).gameObject.SetActive(false);
        newBuilding = (GameObject)Instantiate(cardInformation.BuildingPrefab, Vector3.zero, Quaternion.identity);
        newBuilding.layer = LayerMask.NameToLayer("NewBuilding");
        newBuilding.name = cardInformation.BuildingName;
        buildingSpawn.BuildingPrefab = newBuilding;
        buildingSpawn.BuildingInformation = cardInformation;
    }
}