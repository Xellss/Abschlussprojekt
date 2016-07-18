/////////////////////////////////////////////////
///                                           ///
///      Source Code - Abschlussprojekt       ///
///                                           ///
///           Author: Daniel Lause            ///
///                                           ///
///                                           ///
/////////////////////////////////////////////////
/////////////////////////////////////////////////
/////////////////////////////////////////////////
using System.Collections;

///                                           ///
///      Source Code - Abschlussprojekt       ///
///                                           ///
///           Author: Daniel Lause            ///
///                                           ///
///                                           ///
using UnityEngine;
using UnityEngine.UI;

public class ShopButtonBehaviour : MonoBehaviour
{
    private Animator animator;
    private BuildingInformation buildingCardInformation;
    private Text buildingInformationText;
    private BuildingSpawn buildingSpawn;
    private ShopCardCreator cardCreator;
    private GameState gameState;
    [SerializeField]
    private Text goldAmount;
    private GameObject Ground;
    private bool menuOpen;
    private bool menuOpening;
    [SerializeField]
    private GameObject newBuilding;
    private RepairBuilding repairBuilding;
    private MeshRenderer selectedShopCardRenderer;
    private DestroyBuildedTower sellBuilding;
    private GameObject shop;
    [SerializeField]
    private GameObject shopBuildButton;
    [SerializeField]
    private Text shopGoldAmount;
    private GameObject towerShopCard;
    private TowerSlot towerSlotScript;
    private Transform towerSlotTransform;
    private GameObject wallShopCard;

    [SerializeField]
    GameObject restartWindow;

    public GameObject TowerShopCard
    {
        get { return towerShopCard; }
        set { towerShopCard = value; }
    }

    public GameObject WallShopCard
    {
        get { return wallShopCard; }
        set { wallShopCard = value; }
    }

    public void OnClickLevelManager()
    {
        restartWindow.SetActive(true);
    }
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

            if (!towerSlotScript.BuildingOnSlot)
            {
                shopBuildButton.GetComponent<Button>().interactable = true;
            }
            else
            {
                shopBuildButton.GetComponent<Button>().interactable = false;
                buildingInformationText.text = "Es kann nur ein Gebäude auf jedem Slot gebaut werden.";
            }
        }
    }

    public void OnClickShopCardBuild()
    {
        restartWindow.SetActive(false);

        sellBuilding = towerSlotTransform.GetComponent<DestroyBuildedTower>();
        sellBuilding.BuildingInformation = buildingCardInformation;
        sellBuilding.enabled = true;
        gameState.GoldAmount -= buildingCardInformation.BuildingGoldCost;
        goldAmount.text = gameState.GoldAmount.ToString();

        newBuilding = (GameObject)Instantiate(buildingCardInformation.BuildingPrefab, towerSlotTransform.position, Quaternion.identity);
        newBuilding.layer = LayerMask.NameToLayer(buildingCardInformation.BuildingTypes.ToString());
        newBuilding.name = buildingCardInformation.BuildingName;
        newBuilding.transform.SetParent(towerSlotTransform);
        towerSlotScript.enabled = false;
        newBuilding.tag = "Building";
        buildingSpawn.BuildingPrefab = newBuilding;
        buildingSpawn.BuildingInformation = buildingCardInformation;
        Ground.layer = LayerMask.NameToLayer("Ground");
        repairBuilding = newBuilding.GetComponent<RepairBuilding>();
        repairBuilding.BuildingInfo = buildingCardInformation;
        shopBuildButton.SetActive(false);
        buildingInformationText.text = "Wähle eine Shop Karte aus, um Informationen zu erhalten oder dieses Gebäude zu bauen.";
        towerSlotScript.BuildingOnSlot = true;
        //towerShopCard.SetActive(true);
    }

    public void OnShopCloseClick()
    {
        if (!menuOpen || menuOpening)
            return;
        menuOpen = false;

        if (selectedShopCardRenderer != null)
        {
            selectedShopCardRenderer.enabled = false;
        }
        //towerShopCard.SetActive(true);
        restartWindow.SetActive(false);
        Time.timeScale = 1;
        StopCoroutine("timescale");
        Camera.main.gameObject.GetComponent<Animator>().SetTrigger("BuildMenuClosed");
        animator.SetTrigger("ShopFadeOut");
        //shop.SetActive(false);
        Ground.layer = LayerMask.NameToLayer("Ground");

    }

    public void OnTowerSlotClick(Transform slotPosition, TowerSlot towerSlotScript)
    {
        restartWindow.SetActive(false);
        shopBuildButton.SetActive(false);
        buildingInformationText.text = "Wähle eine Shop Karte aus, um Informationen zu erhalten oder dieses Gebäude zu bauen.";
        this.towerSlotScript = towerSlotScript;
        this.towerSlotTransform = slotPosition;
        if (selectedShopCardRenderer != null)
        {
            selectedShopCardRenderer.enabled = false;
        }
        selectedShopCardRenderer = towerSlotTransform.FindChild("Selected").gameObject.GetComponent<MeshRenderer>();
        selectedShopCardRenderer.enabled = true;
        if (menuOpen || menuOpening)
            return;
        menuOpening = true;
        StopCoroutine("timescale");
        shopGoldAmount.text = gameState.GoldAmount.ToString();
        cardCreator.CanBuyBuilding();
        shopBuildButton.SetActive(false);
        buildingInformationText.text = "Wähle eine Shop Karte aus, um Informationen zu erhalten oder dieses Gebäude zu bauen.";
        //shop.SetActive(true);
        Camera.main.gameObject.GetComponent<Animator>().SetTrigger("BuildMenuOpen");
        animator.SetTrigger("ShopFadeIn");
        StartCoroutine("timescale");
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
        animator = shop.GetComponent<Animator>();
    }

    private void Start()
    {
        towerShopCard = GameObject.Find("ShopCard_Tower");
        wallShopCard = GameObject.Find("ShopCard_Wall");
        //shop.SetActive(false);
    }

    private IEnumerator timescale()
    {
        //if (Time.timeScale == 0)
        //{
        //    Time.timeScale = 1;
        //}
        yield return new WaitForSecondsRealtime(0.75f);
        Time.timeScale = 0;
        menuOpening = false;
        menuOpen = true;
    }
}
