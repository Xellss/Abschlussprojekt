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
using UnityEngine.EventSystems;

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
    private DestroyBuildedTower sellBuilding;
    private RepairBuilding repairBuilding;
    private Animator animator;
    private bool menuOpen;
    private bool menuOpening;

    private MeshRenderer selectedShopCardRenderer;

    private GameObject towerShopCard;

    public GameObject TowerShopCard
    {
        get { return towerShopCard; }
        set { towerShopCard = value; }
    }

    private GameObject wallShopCard;

    public GameObject WallShopCard
    {
        get { return wallShopCard; }
        set { wallShopCard = value; }
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
        }
    }

    public void OnClickShopCardBuild()
    {
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
        Time.timeScale = 1;
        StopCoroutine("timescale");
        Camera.main.gameObject.GetComponent<Animator>().SetTrigger("BuildMenuClosed");
        animator.SetTrigger("ShopFadeOut");
        //shop.SetActive(false);
        Ground.layer = LayerMask.NameToLayer("Ground");
    }

    public void OnTowerSlotClick(Transform slotPosition, TowerSlot towerSlotScript)
    {
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
        shop.SetActive(true);
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

    IEnumerator timescale()
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


