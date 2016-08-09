using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GoldTower : MonoBehaviour {

    GameState gameState;
    Text goldAmountText;

    [SerializeField]
    GameObject goldEffect;

    [SerializeField]
    private bool towerActive;

    public bool TowerActive
    {
        get { return towerActive; }
        set { towerActive = value; }
    }

    [SerializeField]
    private int goldAmount;

    public int GoldAmount
    {
        get { return goldAmount; }
        set { goldAmount = value; }
    }

    [SerializeField]
    private float effectDelay;
    private ShopCardCreator shopCardCreator;
    private WaveSpawn waveSpawner;

    public float EffectDelay
    {
        get { return effectDelay; }
        set { effectDelay = value; }
    }

 


    void Start()
    {
        InvokeRepeating("gold", 0, effectDelay);
    }

    void Awake()
    {
        gameState = (GameState)FindObjectOfType(typeof(GameState));
        goldAmountText = GameObject.Find("GoldAmount").GetComponent<Text>();
        shopCardCreator = GameObject.Find("Canvas").GetComponent<ShopCardCreator>();
        waveSpawner = GameObject.Find("SpawnPoints").GetComponent<WaveSpawn>();

    }

    void gold()
    {
        if (towerActive && !waveSpawner.BuildPhase)
        {
            
            gameState.GoldAmount += goldAmount;
            goldAmountText.text = gameState.GoldAmount.ToString();
            shopCardCreator.CanBuyBuilding();

            StartCoroutine(goldEffectTimer());
        }
    }

    IEnumerator goldEffectTimer()
    {
        goldEffect.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        goldEffect.SetActive(false);
    }
}
