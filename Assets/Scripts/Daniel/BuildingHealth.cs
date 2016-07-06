/////////////////////////////////////////////////
/////////////////////////////////////////////////

using System.Collections;
///                                           ///
///      Source Code - Abschlussprojekt       ///
///                                           ///
///           Author: Daniel Lause            ///
///                                           ///
///                                           ///
using UnityEngine;
using UnityEngine.UI;

public class BuildingHealth : MonoBehaviour
{
    private RectTransform canvasRect;
    [SerializeField]
    private float currentHealth;
    private DestroyBuildedTower destroyBuilding;
    private GameState globalScripts;
    private RectTransform hpBackgroundImage;
    private GameObject hpCanvas;
    private RectTransform hpImage;
    [SerializeField]
    private float maxHealth;

    [SerializeField]
    Slider hpSlider;

    private Renderer renderer;

    private TowerController towerController;

    private TowerSlot towerSlotScript;

    [SerializeField]
    private WaveSpawn waveSpawn;

    [SerializeField]
    private GameObject winLoseObject;

    [SerializeField]
    private WinLoseWindow winLoseScript;

    public float MaxHealth
    {
        get { return maxHealth; }
        set { maxHealth = value; }
    }

    public void AddHealth(float hp)
    {
        currentHealth += hp;
    }

    public void EditMaxHealth(float newMaxHealth)
    {
        maxHealth = newMaxHealth;
    }

    public int LevelStars()
    {
        if (currentHealth == maxHealth)
        {
            return 3;
        }
        else if (currentHealth < maxHealth)
        {
            return 2;
        }
        else if (maxHealth / 2 > currentHealth)
        {
            return 1;
        }
        else
            return 0;
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
        waveSpawn = GameObject.Find("SpawnPoints").GetComponent<WaveSpawn>();
    }

    private void LateUpdate()
    {
        if (currentHealth < 0)
            currentHealth = 0;

        if (currentHealth > maxHealth)
            currentHealth = maxHealth;

        if (currentHealth < maxHealth)
        {
            //hpImage.sizeDelta = new Vector2(currentHealth / 100, hpImage.rect.height);
            hpCanvas.SetActive(true);
            hpSlider.value = currentHealth;
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
            winLoseScript.WinLoseWave(false, waveSpawn.EnemyInfo, 0);
            currentHealth = maxHealth;
            GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (var enemy in enemys)
            {
                enemy.GetComponent<EnemyHP>().Reset();
            }
        }
        else
        {
            //towerSlotScript.enabled = true;
            destroyBuilding.enabled = false;
            if (renderer != null)
            {
                renderer.material.color = Color.red;
            }
            else
                GetComponentInChildren<MeshRenderer>().material.color = Color.red;

            gameObject.tag = "Destroyed";
            transform.parent.gameObject.tag = "Destroyed";
            if (towerController != null)
            {
                towerController.CanShoot = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy" && gameObject.tag == "Building")
        {
            onTriggerEnemy(other);
        }
        if (other.gameObject.tag == "LaserBullet" && gameObject.tag == "Building")
        {
            onTriggerBullet(other);
        }
        if (other.gameObject.tag == "Asteroid" && gameObject.tag == "Building")
        {
            onTriggerAsteroid(other.gameObject);

        }
    }
    private void onTriggerEnemy(Collider other)
    {
        EnemyHP enemyHP = other.gameObject.GetComponent<EnemyHP>();
        StartCoroutine(reduceHealth(5, enemyHP.CurrentHealth));
        //other.gameObject.SetActive(false);
        enemyHP.Decrease(enemyHP.CurrentHealth);
        //other.gameObject.GetComponent<EnemyHP>().Reset();
    }
    private void onTriggerBullet(Collider other)
    {
        StartCoroutine(reduceHealth(5, other.GetComponent<LaserInfos>().Damage));
        other.gameObject.SetActive(false);
        other.gameObject.transform.position = new Vector3(0, 0, 40);
    }
    private void onTriggerAsteroid(GameObject other)
    {
        AsteroidEnemyKI enemyHP = other.GetComponent<AsteroidEnemyKI>();
        int damage = enemyHP.Damage;
        if (gameObject.layer == LayerMask.NameToLayer("Wall"))
        {
            damage = 1;
        }
        StartCoroutine(reduceHealth(5, damage));
        other.SetActive(false);
        other.transform.position = new Vector3(0, 0, 40);
        waveSpawn.Enemys--;
    }
    private void setMaxSize(RectTransform rectangle)
    {
        rectangle.sizeDelta = new Vector2(maxHealth / 100, rectangle.rect.height);
    }

    private void Start()
    {
        towerSlotScript = transform.GetComponentInParent<TowerSlot>();
        destroyBuilding = transform.GetComponentInParent<DestroyBuildedTower>();
        setMaxSize(canvasRect);
        //setMaxSize(hpImage);
        //setMaxSize(hpBackgroundImage);
        renderer = GetComponent<Renderer>();
        currentHealth = maxHealth;
        hpSlider.maxValue = maxHealth;
        if (GetComponent<TowerController>() != null)
        {
            towerController = GetComponent<TowerController>();
        }
    }
    IEnumerator reduceHealth(int step, int total)
    {
        int remaining = total;
        while (remaining > 0)
        {
            currentHealth -= Mathf.Min(remaining, step);
            // Anm. @Fabio: Approved by Jöran. Andernfalls Bug innerhalb Unity.
            if (currentHealth == maxHealth / 2)
                currentHealth--;
            remaining -= step;
            yield return null;
        }
    }
}
