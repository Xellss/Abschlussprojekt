/////////////////////////////////////////////////
///                                           ///
///      Source Code - Abschlussprojekt       ///
///                                           ///
///           Author: Daniel Lause            ///
///                                           ///
///                                           ///
/////////////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawn : MonoBehaviour
{
    private bool clearWave = false;

    [SerializeField]
    private Edge[] edges;

    [SerializeField]
    private Image skipButton;

    [SerializeField]
    private GameObject buildMenu;

    public GameObject BuildMenu
    {
        get { return buildMenu; }
        set { buildMenu = value; }
    }

    private int enemyCountPerSpawnPoint;

    private int enemys = 0;

    [SerializeField]
    private MapButtonBehaviour mapBehaviour;

    private GameObject newEnemy;

    [SerializeField]
    private bool skipBuild = false;

    public bool SkipBuild
    {
        get { return skipBuild; }
        set { skipBuild = value; }
    }


    [SerializeField]
    private bool spawn;

    private int spawnPointCounter;

    private List<Vector3> spawnPoints;

    [SerializeField]
    private BuildingHealth sunHealth;

    private int totalEnemyCount = 0;

    public int TotalEnemyCount
    {
        get { return totalEnemyCount; }
        set { totalEnemyCount = value; }
    }


    private int waveCounter = 0;

    private int waveEnemyCount = 0;

    public int WaveEnemyCount
    {
        get { return waveEnemyCount; }
        set { waveEnemyCount = value; }
    }

    public void Skip()
    {
        skipBuild = !skipBuild;

        if (skipBuild)
        {
            skipButton.color = Color.red;
        }
        else
            skipButton.color = Color.white;
    }

    [SerializeField]
    private EnemyWorldMapInfo waveInfo;

    private Wave[] waves;

    private bool waveStart = false;

    private WinLoseWindow winLoseScript;

    [SerializeField]
    private GameObject winLoseWindow;
    private ShopCardCreator shopCardCreator;
    private Text goldAmountText;
    private GameState gameState;

    public int EnemyCountPerSpawnPoint
    {
        get
        { return enemyCountPerSpawnPoint; }

        set
        { enemyCountPerSpawnPoint = value; }
    }

    public int Enemys
    {
        get
        {
            return enemys;
        }

        set
        {
            enemys = value;
        }
    }

    public EnemyWorldMapInfo WaveInfo
    {
        get { return waveInfo; }
        set { waveInfo = value; }
    }

    public Wave[] Waves
    {
        get { return waves; }
        set { waves = value; }
    }

    public bool WaveStart
    {
        get
        {
            return waveStart;
        }

        set
        {
            waveStart = value;
        }
    }

    public void CreateSpawnpoints()
    {
        spawnPoints.Clear();

        //for (int i = 0; i < Waves[waveCounter].SpawnPoints; i++)
        //{
        Vector3 newPosition = spawnPosition();
        spawnPoints.Add(newPosition);
        //}
    }

    public void SpawnEnemy()
    {
        foreach (var spawnPoint in spawnPoints)
        {
            for (int k = 0; k < Waves[waveCounter].EnemyCount; k++)
            {
                newEnemy = ObjectPool.Instance.GetPooledObject(Waves[waveCounter].EnemyPrefab);
                newEnemy.transform.position = spawnPoint;
                waveEnemyCount++;
                enemys++;
                waveStart = true;
            }
        }
        waveCounter++;
        if (waveCounter >= waves.Length)
        {
            waveCounter = 0;
            spawnPoints.Clear();
        }
        else
        {
            if (!Waves[waveCounter - 1].CanBuildAfterWave)
            {
                StartCoroutine(spawnerDelay(Waves[waveCounter].DelayToLastWave));
            }
            else
            {
                StartCoroutine(buildTime());
            }
        }
    }

    private void Awake()
    {
        spawnPoints = new List<Vector3>();
        winLoseScript = winLoseWindow.GetComponent<WinLoseWindow>();
    }

    private IEnumerator buildTime()
    {
        if (waveEnemyCount > 0)
        {
            yield return null;
            StartCoroutine(buildTime());
        }
        else
        {
            if (skipBuild)
            {
                StartCoroutine(spawnerDelay(Waves[waveCounter].DelayToLastWave));
                gameState.GoldAmount += Waves[waveCounter - 1].WaveGoldReward;
                goldAmountText.text = gameState.GoldAmount.ToString();
                shopCardCreator.CanBuyBuilding();
            }
            else
            {
                gameState.GoldAmount += Waves[waveCounter-1].WaveGoldReward;
                goldAmountText.text = gameState.GoldAmount.ToString();
                buildMenu.SetActive(true);
                shopCardCreator.CanBuyBuilding();
                yield return null;
            }
        }
    }
    public void StartWaveAfterBuild()
    {
        buildMenu.SetActive(false);
        StartCoroutine(spawnerDelay(Waves[waveCounter].DelayToLastWave));
    }
    private IEnumerator spawnerDelay(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        CreateSpawnpoints();
        SpawnEnemy();
    }

    private Vector3 spawnPosition()
    {
        int sideNumber = Random.Range(0, edges.Length);

        Edge edge = edges[sideNumber];

        return Vector3.Lerp(edge.First.position, edge.Second.position, Random.value);
    }

    private void Start()
    {
        shopCardCreator = GameObject.Find("Canvas").GetComponent<ShopCardCreator>();
        gameState = (GameState)FindObjectOfType(typeof(GameState));
        goldAmountText = GameObject.Find("GoldAmount").GetComponent<Text>();

        if (waveInfo != null)
        {
            waves = waveInfo.Waves;

            foreach (var wave in waves)
            {
                totalEnemyCount += wave.EnemyCount;
            }
        }
    }

    private void Update()
    {
        if (waveStart && totalEnemyCount == 0)
        {
            waveStart = false;
            winLoseWindow.SetActive(true);
            winLoseScript.WinLoseWave(true, waveInfo, sunHealth.LevelStars());
        }
    }
}
