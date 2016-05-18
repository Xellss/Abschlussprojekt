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
    [SerializeField]
    private float maxHealth;
    [SerializeField]
    private float currentHealth;
    private RectTransform hpBackgroundImage;
    private GameObject hpCanvas;
    private RectTransform canvasRect;
    private RectTransform hpImage;
    private TowerSlot towerSlotScript;

    [SerializeField]
    private onLoose globalScripts;

    private void Awake()
    {
        globalScripts = GameObject.Find("GlobalScripts").GetComponent<onLoose>();
        hpCanvas = transform.FindChild("HP").gameObject;
        canvasRect = hpCanvas.GetComponent<RectTransform>();
        hpBackgroundImage = hpCanvas.transform.FindChild("HPBackgroundImage").GetComponent<RectTransform>();
        hpImage = hpCanvas.transform.FindChild("HPImage").GetComponent<RectTransform>();
    }

    private void Start()
    {
        towerSlotScript = transform.GetComponentInParent<TowerSlot>();
        setMaxSize(canvasRect);
        setMaxSize(hpImage);
        setMaxSize(hpBackgroundImage);

        currentHealth = maxHealth;

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy" && gameObject.tag == "Building")
        {
            currentHealth -= other.gameObject.GetComponent<EnemyHP>().CurrentHealth;
            other.gameObject.SetActive(false);
            other.gameObject.GetComponent<EnemyHP>().Reset();
        }
    }

    void FixedUpdate()
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

    private void setMaxSize(RectTransform rectangle)
    {
        rectangle.sizeDelta = new Vector2(maxHealth / 100, rectangle.rect.height);
    }

    public void RemoveHealth(float Damage)
    {
        currentHealth -= Damage;
    }
    public void AddHealth(float hp)
    {
        currentHealth += hp;
    }
    public void EditMaxHealth(float newMaxHealth)
    {
        maxHealth = newMaxHealth;
    }


    private void onDeath()
    {
        if (this.gameObject.layer == LayerMask.NameToLayer("MainBuilding"))
        {
        globalScripts.LoseScreen.SetActive(true);
        globalScripts.gameObject.SetActive(false);
        }
        towerSlotScript.enabled = true;
        GameObject.Destroy(this.gameObject);
    }
}
