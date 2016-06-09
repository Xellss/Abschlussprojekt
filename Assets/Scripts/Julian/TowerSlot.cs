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

public class TowerSlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler, IPointerUpHandler
{
    private GameState gameState;
    private Text gold;
    private GameObject ground;
    private bool hasTower = false;
    private Renderer myRenderer;
    private Transform myTransform;
    private ShopButtonBehaviour shopButtonBehavior;
    //[SerializeField]
    //private TowerController towerPrefab;

    public void OnPointerClick(PointerEventData eventData)
    {
        //ground.layer = LayerMask.NameToLayer("Default");
        if (gameObject.GetComponent<BaseTerrainManager>() == null)
        {
        shopButtonBehavior.OnTowerSlotClick(transform, this);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //myRenderer.material.color = Color.cyan;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //myRenderer.material.color = Color.green;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        //ground.layer = LayerMask.NameToLayer("Ground");
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
    }
}
