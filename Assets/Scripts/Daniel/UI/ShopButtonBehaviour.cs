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
    //private GameObject buildButton;
    private BuildingInformation buildingCardInformation;
    private Text buildingInformationText;
    private BuildingSpawn buildingSpawn;
    private ShopCardCreator cardCreator;
    private BuildingCheckSpawnPosition checkPosition;
    private GameState gameState;
    private GameObject missionButton;
    private GameObject newBuilding;
    [SerializeField]
    Text goldAmount;
    //[SerializeField]
    //private PlayerInformation playerInformation;
    private GameObject shop;
    private GameObject shopButton;
    [SerializeField]
    private Text shopGoldAmount;
    [SerializeField]
    GameObject shopBuildButton;
    [SerializeField]
    GameObject MainCamera;
    [SerializeField]
    GameObject RTSCamera;
    GameObject newBuildingCanvas;
    GameObject[] terrainBuyButtons;
    public void OnClickBuild()
    {
        checkPosition = newBuilding.GetComponent<BuildingCheckSpawnPosition>();
        if (checkPosition.CanBuild)
        {
            gameState.GoldAmount-= buildingCardInformation.BuildingGoldCost;
            goldAmount.text = gameState.GoldAmount.ToString();
            newBuilding.layer = LayerMask.NameToLayer(buildingCardInformation.BuildingTypes.ToString());
            newBuilding.tag = "Building";
            Component.Destroy(newBuilding.GetComponent<Rigidbody>());
            Component.Destroy(newBuilding.GetComponent<BuildingCheckSpawnPosition>());
            newBuilding.GetComponent<BoxCollider>().isTrigger = true;
            //buildButton.SetActive(false);
            shopButton.SetActive(true);
            missionButton.SetActive(true);
            //gameState.Buildings.Add(new BuildingModel(newBuilding, newBuilding.transform));
            newBuildingCanvas.SetActive(false);
            terrainButtonEnable(true);
            RTSCamera.SetActive(true);
            MainCamera.SetActive(false);

        }
    }

    public void OnClickShopCard(BuildingSpawn buildingSpawn, BuildingInformation cardInformation, GameObject buildButton, Text buildingInformation, Button shopCardBuildButton)
    {
        //this.buildButton = buildButton;
        this.buildingSpawn = buildingSpawn;
        //buildingInformationText = buildingInformation;

        if (cardInformation != null)
        {
            buildingInformation.text = cardInformation.BuildingInformationText.ToString();
            this.buildingCardInformation = cardInformation;
            shopBuildButton.SetActive(true);
            if (gameState.GoldAmount>= cardInformation.BuildingGoldCost)
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
        shopButton.SetActive(false);
        missionButton.SetActive(false);
        shop.SetActive(false);
        newBuilding = (GameObject)Instantiate(buildingCardInformation.BuildingPrefab, new Vector3(0,0,0), Quaternion.identity);
        Rigidbody rigid = newBuilding.AddComponent<Rigidbody>();
        rigid.isKinematic = true;
        newBuilding.AddComponent<BuildingCheckSpawnPosition>();
        newBuilding.layer = LayerMask.NameToLayer("NewBuilding");
        newBuilding.name = buildingCardInformation.BuildingName;
        buildingSpawn.BuildingPrefab = newBuilding;
        buildingSpawn.BuildingInformation = buildingCardInformation;
        newBuildingCanvas = newBuilding.transform.FindChild("Canvas").gameObject;
        newBuildingCanvas.SetActive(true);
        terrainButtonEnable(false);
        MainCamera.SetActive(true);
        RTSCamera.SetActive(false);
    }

    public void OnShopClick()
    {
        shopGoldAmount.text = gameState.GoldAmount.ToString();
        cardCreator.CanBuyBuilding();
        shopBuildButton.SetActive(false);
        buildingInformationText.text = "Wähle eine Shop Karte aus, um Informationen zu erhalten oder dieses Gebäude zu bauen.";
        shop.SetActive(true);
    }

    public void OnShopCloseClick()
    {
        shop.SetActive(false);
    }

    public void OnCancelBuildClick()
    {
        //playerInformation.TotalGoldAmount += buildingCardInformation.BuildingGoldCost;
        GameObject.Destroy(newBuilding);
        //buildButton.SetActive(false);
        shopButton.SetActive(true);
        missionButton.SetActive(true);
        terrainButtonEnable(true);
        RTSCamera.SetActive(true);
        MainCamera.SetActive(false);
    }

    private void Awake()
    {
        gameState = (GameState)FindObjectOfType(typeof(GameState));
        gameObject.GetComponent<BuildingSpawn>();
        shopButton = transform.FindChild("ShopButton").gameObject;
        missionButton = transform.FindChild("MissionButton").gameObject;
        shop = transform.FindChild("Shop").gameObject;
        cardCreator = GetComponent<ShopCardCreator>();
        buildingInformationText = cardCreator.BuildingInformation;

        terrainBuyButtons = GameObject.FindGameObjectsWithTag("BuyButton");
        goldAmount.text = gameState.GoldAmount.ToString();
    }

    private void terrainButtonEnable(bool enable)
    {
        foreach (var buyButton in terrainBuyButtons)
        {
            buyButton.SetActive(enable);
        }
    }
}
