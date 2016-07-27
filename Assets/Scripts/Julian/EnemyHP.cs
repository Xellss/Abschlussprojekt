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
    private GameState gameState;
    private Text gold;
    [SerializeField]
    private int GoldDropAmount = 5;
    private ItemDrop itemdrop;
    [SerializeField]
    private int maxHealth = 100;

    EnemyKi enemyKi;

    private WaveSpawn waveSpawner;

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
        if (this.gameObject.tag == "Enemy" && enemyKi.EnemyType != EnemyTypes.Tank)
        {
            transform.localScale -= new Vector3(0.5f, 0.5f, 0.5f);
        }

        if (currentHealth <= 0)
        {
            gameState.GoldAmount += GoldDropAmount;
            gold.text = gameState.GoldAmount.ToString();
            itemdrop.DropItemCheck();
            waveSpawner.WaveEnemyCount--;
            waveSpawner.TotalEnemyCount--;
            Reset();
        }
    }

    public void Reset()
    {
        gameObject.SetActive(false);
        if (this.gameObject.tag == "Enemy" && enemyKi.EnemyType != EnemyTypes.Tank)
        {
            transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        }
        transform.position = new Vector3(0, 0, 40);
        CurrentHealth = MaxHealth;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bomb")
        {
            Bomb bomb = other.gameObject.GetComponent<Bomb>();
            Rigidbody bombRigid = other.gameObject.GetComponent<Rigidbody>();
            bombRigid.velocity = Vector3.zero;
            bomb.PlayAnimation();
            Decrease(bomb.Damage);
        }
        if (other.gameObject.tag == "Bullet")
        {
            BulletController bullet = other.gameObject.GetComponent<BulletController>();
            Decrease(bullet.DamagePoints);
            other.gameObject.SetActive(false);
        }
    }

    private void Awake()
    {
        enemyKi = GetComponent<EnemyKi>();
        gameState = (GameState)FindObjectOfType(typeof(GameState));
        CurrentHealth = MaxHealth;
        itemdrop = GetComponent<ItemDrop>();
        gold = GameObject.Find("GoldAmount").GetComponent<Text>();
        waveSpawner = GameObject.Find("SpawnPoints").GetComponent<WaveSpawn>();
    }
}
