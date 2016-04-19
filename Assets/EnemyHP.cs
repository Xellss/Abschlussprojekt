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
    private int maxHealthPoints = 100;
    [SerializeField]
    private int healthPoints = 100;
    [SerializeField]

    public int MaxHealthPoints
    {
        get { return maxHealthPoints; }
        set { maxHealthPoints = value; }
    }

    public int HealthPoints
    {
        get { return healthPoints; }
        set { healthPoints = value; }
    }

    public void Decrease(int damage)
    {
        healthPoints = healthPoints - damage;
        if (healthPoints < 0)
        {
            print("destroy");
            gameObject.SetActive(false);
        }
    }
}
