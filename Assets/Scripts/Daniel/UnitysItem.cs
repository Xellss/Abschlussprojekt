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

public class UnitysItem : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler
{
    private GameState gameState;
    private Text goldText;
    private ShopCardCreator shopCardCreator;
    [SerializeField]
    private float timerTime = 10;
    [SerializeField]
    private int unitysOnClick = 50;

    public void OnPointerClick(PointerEventData eventData)
    {
        gameState.GoldAmount += unitysOnClick;
        goldText.text = gameState.GoldAmount.ToString();
        shopCardCreator.CanBuyBuilding();
        GameObject.Destroy(this.gameObject);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        gameState.GoldAmount += unitysOnClick;
        goldText.text = gameState.GoldAmount.ToString();
        shopCardCreator.CanBuyBuilding();
        GameObject.Destroy(this.gameObject);
    }

    private void Start()
    {
        shopCardCreator = GameObject.Find("Canvas").GetComponent<ShopCardCreator>();
        goldText = GameObject.Find("GoldAmount").GetComponent<Text>();
        gameState = GameObject.Find("GlobalScripts").GetComponent<GameState>();
    }

    private void Update()
    {
        if (timerTime <= 0)
        {
            gameState.GoldAmount += unitysOnClick;
            goldText.text = gameState.GoldAmount.ToString();
            shopCardCreator.CanBuyBuilding();
            GameObject.Destroy(this.gameObject);
        }
        else
            timerTime -= Time.deltaTime;
    }
}
