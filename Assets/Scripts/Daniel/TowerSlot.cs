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

public class TowerSlot : MonoBehaviour/*, IPointerClickHandler*/
{
    private bool buildingOnSlot = false;
    private float delta;
    private GameState gameState;
    private Text gold;
    private GameObject ground;
    private bool hasTower = false;
    private Renderer myRenderer;
    private Transform myTransform;
    //[SerializeField]
    //private TowerController towerPrefab;
    private ShopButtonBehaviour shopBehavoiur;
    private ShopButtonBehaviour shopButtonBehavior;
    [SerializeField]
    private bool wallSlot = false;

    public bool BuildingOnSlot
    {
        get { return buildingOnSlot; }
        set { buildingOnSlot = value; }
    }

    //public void OnPointerClick(PointerEventData eventData)
    //{
    //    //ground.layer = LayerMask.NameToLayer("Default");
    //    if (gameObject.GetComponent<BaseTerrainManager>() == null)
    //    {
    //        if (wallSlot)
    //        {
    //            shopBehavoiur.TowerCardsSetActive(false);
    //            shopBehavoiur.WallCardsSetActive(true);
    //        }
    //        else
    //        {
    //            shopBehavoiur.TowerCardsSetActive(true);
    //            shopBehavoiur.WallCardsSetActive(false);
    //        }
    //        shopButtonBehavior.OnTowerSlotClick(transform, this);
    //    }
    //}

    private void Awake()
    {
        //ground = GameObject.Find("Ground");
        shopButtonBehavior = (ShopButtonBehaviour)FindObjectOfType(typeof(ShopButtonBehaviour));
        gameState = (GameState)FindObjectOfType(typeof(GameState));
        myTransform = GetComponent<Transform>();
        myRenderer = GetComponent<Renderer>();
        if (GameObject.Find("GoldAmountOutpost") != null)
            gold = GameObject.Find("GoldAmountOutpost").GetComponent<Text>();
        shopBehavoiur = GameObject.Find("Canvas").GetComponent<ShopButtonBehaviour>();
    }
}
