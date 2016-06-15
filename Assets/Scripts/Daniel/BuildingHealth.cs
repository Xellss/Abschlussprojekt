/////////////////////////////////////////////////
///                                           ///
///      Source Code - Abschlussprojekt       ///
///                                           ///
///           Author: Daniel Lause            ///
///                                           ///
///                                           ///
/////////////////////////////////////////////////

using UnityEngine;

public class BuildingHealth : MonoBehaviour
{
    private RectTransform canvasRect;
    [SerializeField]
    private float currentHealth;
    private GameState globalScripts;
    private RectTransform hpBackgroundImage;
    private GameObject hpCanvas;
    private RectTransform hpImage;
    [SerializeField]
    private float maxHealth;
    private TowerSlot towerSlotScript;
    [SerializeField]
    private WaveSpawn waveSpawn;
    [SerializeField]
    private GameObject winLoseObject;
    [SerializeField]
    private WinLoseWindow winLoseScript;

    public void AddHealth(float hp)
    {
        currentHealth += hp;
    }

    public void EditMaxHealth(float newMaxHealth)
    {
        maxHealth = newMaxHealth;
    }

    public void RemoveHealth(float Damage)
    {
        currentHealth -= Damage;
    }

    private void Awake()
    {
        globalScripts = GameObject.Find("GlobalScripts").GetComponent<GameState>();
        hpCanvas = transform.FindChild("HP").gameObject;
        canvasRect = hpCanvas.GetComponent<RectTransform>();
        hpBackgroundImage = hpCanvas.transform.FindChild("HPBackgroundImage").GetComponent<RectTransform>();
        hpImage = hpCanvas.transform.FindChild("HPImage").GetComponent<RectTransform>();
    }

    private void FixedUpdate()
    {
        if (currentHealth < 0)
            currentHealth = 0;

        if (currentHealth > maxHealth)
            currentHealth = maxHealth;

        if (currentHealth < maxHealth)
        {
            hpCanvas.SetActive(true);
            hpImage.sizeDelta = new Vector2(currentHealth / 100, hpImage.rect.height);
        }
        else
            hpCanvas.SetActive(false);

        if (currentHealth == 0)
        {
            onDeath();
        }
    }

    private void onDeath()
    {
        if (this.gameObject.layer == LayerMask.NameToLayer("MainBuilding"))
        {
            waveSpawn.WaveStart = false;
            waveSpawn.Enemys = 0;
            winLoseObject.SetActive(true);
            winLoseScript.WinLoseWave(false, waveSpawn.EnemyInfo);
            currentHealth = maxHealth;
            GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (var enemy in enemys)
            {
                enemy.GetComponent<EnemyHP>().Reset();
            }
        }
        else
        {
            towerSlotScript.enabled = true;
        GameObject.Destroy(this.gameObject);

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy" && gameObject.tag == "Building")
        {
            EnemyHP enemyHP = other.gameObject.GetComponent<EnemyHP>();
            currentHealth -= enemyHP.CurrentHealth;
            //other.gameObject.SetActive(false);
            enemyHP.Decrease(enemyHP.CurrentHealth);
            //other.gameObject.GetComponent<EnemyHP>().Reset();
        }
    }

    private void setMaxSize(RectTransform rectangle)
    {
        rectangle.sizeDelta = new Vector2(maxHealth / 100, rectangle.rect.height);
    }

    private void Start()
    {
        towerSlotScript = transform.GetComponentInParent<TowerSlot>();
        setMaxSize(canvasRect);
        setMaxSize(hpImage);
        setMaxSize(hpBackgroundImage);

        currentHealth = maxHealth;
    }
}
