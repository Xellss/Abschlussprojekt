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
    [SerializeField]

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
    }

    public void Decrease(int damage)
    {
        currentHealth = currentHealth - damage;
        transform.localScale -= new Vector3(0.5f, 0.5f, 0.5f);

        if (currentHealth <= 0)
        {

            gameObject.SetActive(false);
        }
    }
}
