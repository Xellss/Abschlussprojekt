/////////////////////////////////////////////////
///                                           ///
///      Source Code - Abschlussprojekt       ///
///                                           ///
///           Author: Julian Hopp             ///
///                                           ///
///                                           ///
/////////////////////////////////////////////////

using UnityEngine;
using System.Collections;

public class EnemyHP : MonoBehaviour
{
    [SerializeField]
    private int maxHealth = 100;
    [SerializeField]
    private int currentHealth = 100;

    ItemDrop itemdrop;

    public int MaxHealth
    {
        get { return maxHealth; }
        set { maxHealth = value; }
    }

    public int CurrentHealth
    {
        get { return currentHealth; }
        set { currentHealth = value; }
    }

    void Awake()
    {
        CurrentHealth = MaxHealth;
        itemdrop = GetComponent<ItemDrop>();
    }

    public void Decrease(int damage)
    {
        currentHealth = currentHealth - damage;
        transform.localScale -= new Vector3(0.5f, 0.5f, 0.5f);

        if (currentHealth <= 0)
        {
            itemdrop.DropItemCheck();
            gameObject.SetActive(false);
            transform.position = new Vector3(0, 2, 0);
            transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        }
    }
}
