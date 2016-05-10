/////////////////////////////////////////////////
///                                           ///
///      Source Code - Abschlussprojekt       ///
///                                           ///
///           Author: Julian Hopp             ///
///                                           ///
///                                           ///
/////////////////////////////////////////////////

using UnityEngine;
using UnityEngine.UI;

public class EnemyHP : MonoBehaviour
{
    [SerializeField]
    private int currentHealth = 100;
    private Text gold;
    [SerializeField]
    private int GoldDropAmount = 5;
    private ItemDrop itemdrop;
    [SerializeField]
    private int maxHealth = 100;

    public int CurrentHealth
    {
        get { return currentHealth; }
        set { currentHealth = value; }
    }

    public int MaxHealth
    {
        get { return maxHealth; }
        set { maxHealth = value; }
    }

    public void Decrease(int damage)
    {
        currentHealth = currentHealth - damage;
        transform.localScale -= new Vector3(0.5f, 0.5f, 0.5f);

        if (currentHealth <= 0)
        {
            LevelManager.Money += GoldDropAmount;
            gold.text = LevelManager.Money.ToString();
            itemdrop.DropItemCheck();
            Reset();
        }
    }

    public void Reset()
    {
        gameObject.SetActive(false);
        transform.position = new Vector3(0, 2, 0);
        transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        CurrentHealth = MaxHealth;
    }

    private void Awake()
    {
        CurrentHealth = MaxHealth;
        itemdrop = GetComponent<ItemDrop>();
        gold = GameObject.Find("GoldAmount").GetComponent<Text>();
        gold.text = LevelManager.Money.ToString();
    }
}
