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

public class WaveSpawn : MonoBehaviour
{
    [SerializeField]
    private Edge[] edges;
    [SerializeField]
    private int enemyCountPerSpawnPoint;
    [SerializeField]
    private PoolPrefab enemyPrefab;
    private GameObject newEnemy;
    [SerializeField]
    private bool spawn;
    private float spawnDelay;
    [SerializeField]
    private int spawnPointCounter;
    [SerializeField]
    private List<Vector3> spawnPoints;
    private int waveCounter = 0;
    private Wave[] waves;

 
    [SerializeField]
    private GameObject winLoseWindow;
    private WinLoseWindow winLoseScript;

    private EnemyWorldMapInfo enemyInfo;

    public EnemyWorldMapInfo EnemyInfo
    {
        get { return enemyInfo; }
        set { enemyInfo = value; }
    }

    [SerializeField]
    private MapButtonBehaviour mapBehaviour;
    private int enemys = 0;
    private bool waveStart = false;
    private bool clearWave = false;
    public int EnemyCountPerSpawnPoint
    {
        get
        { return enemyCountPerSpawnPoint; }

        set
        { enemyCountPerSpawnPoint = value; }
    }

    public PoolPrefab EnemyPrefab
    {
        get
        { return enemyPrefab; }

        set
        { enemyPrefab = value; }
    }

    public float SpawnDelay
    {
        get
        {
            return spawnDelay;
        }

        set
        {
            spawnDelay = value;
        }
    }

    public Wave[] Waves
    {
        get { return waves; }
        set { waves = value; }
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

    public void SpawnEnemy()
    {
        clearWave = false;
        for (int i = 0; i < spawnPointCounter; i++)
        {
            spawnPoints.Add(spawnPosition());
        }

        foreach (var spawnPoint in spawnPoints)
        {
            for (int k = 0; k < Waves[waveCounter].enemyPerWave; k++)
            {
                newEnemy = ObjectPool.Instance.GetPooledObject(enemyPrefab);
                newEnemy.transform.position = spawnPoint;
                enemys++;
        waveStart = true;
            }
        }
        waveCounter++;
        if (waveCounter >= waves.Length)
            waveCounter = 0;
        else
        {
        StartCoroutine(spawnerDelay(spawnDelay));
        }
        spawnPoints.Clear();
    }

    private void Awake()
    {
        spawnPoints = new List<Vector3>();
        winLoseScript = winLoseWindow.GetComponent<WinLoseWindow>();
    }

    private IEnumerator spawnerDelay(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        SpawnEnemy();
    }

    private Vector3 spawnPosition()
    {
        int sideNumber = Random.Range(0, edges.Length);

        Edge edge = edges[sideNumber];

        return Vector3.Lerp(edge.First.position, edge.Second.position, Random.value);
    }

    private void Update()
    {
        if (waveStart && enemys == 0)
        {
            waveStart = false;
            winLoseWindow.SetActive(true);
            winLoseScript.WinLoseWave(true, enemyInfo);
        }
    }
}
