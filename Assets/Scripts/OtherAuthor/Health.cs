using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public delegate void HealthEvent();
    private HealthEvent OnZeroHealth;

    [SerializeField]
    private int maxHealthPoints = 100;
    [SerializeField]
    private int healthPoints = 100;
    [SerializeField]
    private Image healthBarForeground;

    private float healthBarFillAmount;

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

    void Start()
    {
        if (!healthBarForeground)
            healthBarForeground = GetComponentInChildren<Image>();

        if (!healthBarForeground)
            return;

        if (healthBarForeground.type != Image.Type.Filled)
            healthBarForeground.type = Image.Type.Filled;

        CalculateHealthBarFillAmount();
    }

    void Update()
    {
        if (healthBarForeground.fillAmount != healthBarFillAmount)
            healthBarForeground.fillAmount = healthBarFillAmount;
    }

    public void Increase(int heal)
    {
        if (heal > 0 && healthPoints < maxHealthPoints)
        {
            healthPoints += heal;
            if (healthPoints > maxHealthPoints)
                healthPoints = maxHealthPoints;

            CalculateHealthBarFillAmount();
        }
    }

    public void Decrease(int damage)
    {
        if (damage > 0 && healthPoints > 0)
        {
            healthPoints -= damage;
            if (healthPoints < 0)
                healthPoints = 0;

            CalculateHealthBarFillAmount();
        }

        if(healthPoints <= 0)
        {
            if (OnZeroHealth != null)
                OnZeroHealth();
        }
    }

    private void CalculateHealthBarFillAmount()
    {
        healthBarFillAmount = (float)healthPoints / maxHealthPoints;

        if (healthBarForeground.fillAmount != healthBarFillAmount)
            healthBarForeground.fillAmount = healthBarFillAmount;
    }
}
