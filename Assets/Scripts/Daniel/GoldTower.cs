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

    public float EffectDelay
    {
        get { return effectDelay; }
        set { effectDelay = value; }
    }

    void Start()
    {
        StartCoroutine(effectTimer());
    }

    void Awake()
    {
        gameState = (GameState)FindObjectOfType(typeof(GameState));
        goldAmountText = GameObject.Find("GoldAmount").GetComponent<Text>();
    }

    IEnumerator effectTimer()
    {

        if (towerActive)
        {
            
            gameState.GoldAmount += goldAmount;
            goldAmountText.text = gameState.GoldAmount.ToString();
            StartCoroutine(goldEffectTimer());
            yield return new WaitForSeconds(effectDelay);
            StartCoroutine(effectTimer());
        }
        yield return new WaitForEndOfFrame();
        StartCoroutine(effectTimer());
    }

    IEnumerator goldEffectTimer()
    {
        goldEffect.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        goldEffect.SetActive(false);
    }
}
