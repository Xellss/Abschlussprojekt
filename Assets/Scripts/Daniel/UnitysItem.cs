using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;
using UnityEngine.UI;

public class UnitysItem : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler
{
    
    [SerializeField]
    private int unitysOnClick = 50;
    [SerializeField]
    private float timerTime = 10;

    private GameState gameState;
    private Text goldText;
    private void Start()
    {
        goldText = GameObject.Find("GoldAmount").GetComponent<Text>();
        gameState = GameObject.Find("GlobalScripts").GetComponent<GameState>();
    }
    void Update()
    {

        if (timerTime <= 0)
        {
            GameObject.Destroy(this.gameObject);
        }
        else
            timerTime -= Time.deltaTime;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        gameState.GoldAmount += unitysOnClick;
        goldText.text = gameState.GoldAmount.ToString();
        GameObject.Destroy(this.gameObject);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        gameState.GoldAmount += unitysOnClick;
        goldText.text = gameState.GoldAmount.ToString();
        GameObject.Destroy(this.gameObject);
    }
}
