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

public class BaseTerrainManager : MonoBehaviour
{
    private GameObject buyButton;
    private Renderer renderer;
    private TowerSlot towerSlot;

    [SerializeField]
    private int terrainGoldCost = 500;
    [SerializeField]
    private bool unlock;
    private GameState gameState;
    private Text goldAmount;

    private void Awake()
    {
        goldAmount = GameObject.Find("GoldAmount").GetComponent<Text>();
        towerSlot = GetComponent<TowerSlot>();
        buyButton = transform.FindChild("BuyButton").gameObject;
        renderer = gameObject.GetComponent<Renderer>();
        gameState = (GameState)FindObjectOfType(typeof(GameState));

    }

private void Start()
    {
        if (unlock)
            UnlockTerrain();
        else
            renderer.material.color = Color.red;
    }
  
    public void UnlockTerrain()
    {
        if (unlock || gameState.GoldAmount>= terrainGoldCost)
        {

            if (!unlock)
            {
                gameState.GoldAmount -= terrainGoldCost;
                goldAmount.text = gameState.GoldAmount.ToString();
            }
        towerSlot.enabled = true;
        gameObject.name = "UnlockedTerrain";
        gameObject.tag = "UnlockedTerrain";
        Component.Destroy(this);
        renderer.material.color = Color.green;
        GameObject.Destroy(buyButton);
        }
    }

   
}
