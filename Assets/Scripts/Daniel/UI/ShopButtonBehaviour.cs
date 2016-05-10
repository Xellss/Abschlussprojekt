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
    private GameObject newBuilding;
    private GameObject buildButton;
    private BuildingInformation buildingCardInformation;
    private Text buildingInformationText;
    private GameObject shopButton;
    private GameObject missionButton;
    private GameObject shop;
    private BuildingCheckSpawnPosition checkPosition;

    private ShopCardCreator cardCreator;


    [SerializeField]
    private PlayerInformation playerInformation;

    [SerializeField]
    private Text shopGoldAmount;




    private BuildingSpawn buildingSpawn;

    private void Awake()
    {

        gameObject.GetComponent<BuildingSpawn>();
        shopButton = transform.FindChild("ShopButton").gameObject;
        missionButton = transform.FindChild("MissionButton").gameObject;
        shop = transform.FindChild("Shop").gameObject;
        cardCreator = GetComponent<ShopCardCreator>();
        buildingInformationText = cardCreator.BuildingInformation;
    }

    public void OnClickShopCard(BuildingSpawn buildingSpawn, BuildingInformation cardInformation, GameObject buildButton,Text buildingInformation, Button shopCardBuildButton)
    {
        this.buildButton = buildButton;
        this.buildingSpawn = buildingSpawn;
            //buildingInformationText = buildingInformation;

        if (cardInformation != null)
        {
        buildingInformation.text = cardInformation.BuildingInformationText.ToString();
            this.buildingCardInformation = cardInformation;

        }
    }
    public void OnClickShopCardBuild()
    {
        shopButton.SetActive(false);
        missionButton.SetActive(false);
        shop.SetActive(false);
        newBuilding = (GameObject)Instantiate(buildingCardInformation.BuildingPrefab, Vector3.zero, Quaternion.identity);
        Rigidbody rigid = newBuilding.AddComponent<Rigidbody>();
        rigid.isKinematic = true;
        newBuilding.AddComponent<BuildingCheckSpawnPosition>();
        newBuilding.layer = LayerMask.NameToLayer("NewBuilding");
        newBuilding.name = buildingCardInformation.BuildingName;
        buildingSpawn.BuildingPrefab = newBuilding;
        buildingSpawn.BuildingInformation = buildingCardInformation;
        buildButton.SetActive(true);
    }


    public void OnClickBuild()
    {
        checkPosition = newBuilding.GetComponent<BuildingCheckSpawnPosition>();
        if (checkPosition.CanBuild)
        {
            playerInformation.TotalGoldAmount -= buildingCardInformation.BuildingGoldCost;
            newBuilding.layer = LayerMask.NameToLayer(buildingCardInformation.BuildingTypes.ToString());
            Component.Destroy(newBuilding.GetComponent<Rigidbody>());
            Component.Destroy(newBuilding.GetComponent<BuildingCheckSpawnPosition>());
            newBuilding.GetComponent<BoxCollider>().isTrigger = true;
            buildButton.SetActive(false);
            shopButton.SetActive(true);
            missionButton.SetActive(true);

        }
    }

    public void OnShopClick()
    {
        shopGoldAmount.text = playerInformation.TotalGoldAmount.ToString();
        cardCreator.CanBuyBuilding(playerInformation);
        shop.SetActive(true);
    }

    public void OnShopCloseClick()
    {
        buildingInformationText.text = "";
        shop.SetActive(false);
    }
}