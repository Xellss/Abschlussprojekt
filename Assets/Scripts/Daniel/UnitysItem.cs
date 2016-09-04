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
    private ShopCardCreator shopCardCreator;
    [SerializeField]
    private float timerTime = 10;
    [SerializeField]
    private int unitysOnClick = 50;

    public void OnPointerClick(PointerEventData eventData)
    {
        gameState.GoldAmount += unitysOnClick;
        shopCardCreator.CanBuyBuilding();
        GameObject.Destroy(this.gameObject);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        gameState.GoldAmount += unitysOnClick;
        shopCardCreator.CanBuyBuilding();
        GameObject.Destroy(this.gameObject);
    }

    private void Start()
    {
        shopCardCreator = GameObject.Find("Canvas").GetComponent<ShopCardCreator>();
        gameState = GameObject.Find("GlobalScripts").GetComponent<GameState>();
    }

    private void Update()
    {
        if (timerTime <= 0)
        {
            gameState.GoldAmount += unitysOnClick;
            shopCardCreator.CanBuyBuilding();
            GameObject.Destroy(this.gameObject);
        }
        else
            timerTime -= Time.deltaTime;
    }
}
