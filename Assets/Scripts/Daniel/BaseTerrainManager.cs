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
    private BuyButton buyButton;
    private GameState gameState;
    private Text goldAmount;
    private Renderer renderer;
    [SerializeField]
    private int terrainGoldCost = 500;
    private TowerSlot towerSlot;
    [SerializeField]
    private bool unlock;

    public void UnlockTerrain()
    {
        if (unlock || gameState.GoldAmount >= terrainGoldCost)
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
            //renderer.material.color = Color.green;
            GameObject.Destroy(buyButton);
            buyButton.DestroyAsteroids();
        }
    }

    private void Awake()
    {
        goldAmount = GameObject.Find("GoldAmount").GetComponent<Text>();
        towerSlot = GetComponent<TowerSlot>();
        buyButton = transform.FindChild("BuyButton").GetComponent<BuyButton>();
        //renderer = gameObject.GetComponent<Renderer>();
        gameState = (GameState)FindObjectOfType(typeof(GameState));
    }

    private void Start()
    {
        if (unlock)
            UnlockTerrain();
        //else
            //renderer.material.color = Color.red;
    }
}
