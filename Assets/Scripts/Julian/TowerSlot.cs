/////////////////////////////////////////////////
///                                           ///
///      Source Code - Abschlussprojekt       ///
///                                           ///
///     Author: Julian Hopp & Daniel Lause    ///
///                                           ///
///                                           ///
/////////////////////////////////////////////////

using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TowerSlot : MonoBehaviour, IPointerClickHandler
{
    private GameState gameState;
    private Text gold;
    private GameObject ground;
    private bool hasTower = false;
    private Renderer myRenderer;
    private Transform myTransform;
    private ShopButtonBehaviour shopButtonBehavior;
    [SerializeField]
    private bool wallSlot = false;
    //[SerializeField]
    //private TowerController towerPrefab;
    ShopButtonBehaviour shopBehavoiur;

    public void OnPointerClick(PointerEventData eventData)
    {
        //ground.layer = LayerMask.NameToLayer("Default");
        if (gameObject.GetComponent<BaseTerrainManager>() == null)
        {
            shopButtonBehavior.OnTowerSlotClick(transform, this);

            if (wallSlot)
            {
                shopBehavoiur.TowerShopCard.SetActive(false);
            }
            else
            {
                shopBehavoiur.TowerShopCard.SetActive(true);
            }
        }
    }
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
