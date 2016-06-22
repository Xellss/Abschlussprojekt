﻿/////////////////////////////////////////////////
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
    private bool clearWave = false;
    [SerializeField]
    private Edge[] edges;
    [SerializeField]
    private int enemyCountPerSpawnPoint;
    private EnemyWorldMapInfo enemyInfo;
    [SerializeField]
    private PoolPrefab enemyPrefab;
    private int enemys = 0;
    [SerializeField]
    private EnemyWorldMapInfo enemyScriptable;
    [SerializeField]
    private GameObject lookAtSpawnPrefab;
    [SerializeField]
    private MapButtonBehaviour mapBehaviour;
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
    private bool waveStart = false;
    private WinLoseWindow winLoseScript;
    [SerializeField]
    private GameObject winLoseWindow;

    [SerializeField]
    BuildingHealth sunHealth;

    public int EnemyCountPerSpawnPoint
    {
        get
        { return enemyCountPerSpawnPoint; }

        set
        { enemyCountPerSpawnPoint = value; }
    }

    public EnemyWorldMapInfo EnemyInfo
    {
        get { return enemyInfo; }
        set { enemyInfo = value; }
    }

    public PoolPrefab EnemyPrefab
    {
        get
        { return enemyPrefab; }

        set
        { enemyPrefab = value; }
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
        if (!waveStart)
        {
            for (int i = 0; i < spawnPointCounter; i++)
            {
                Vector3 newPosition = spawnPosition();
                spawnPoints.Add(newPosition);
                GameObject lookAtSpawn = (GameObject)Instantiate(lookAtSpawnPrefab, Vector3.zero, Quaternion.identity);
                lookAtSpawn.GetComponent<LookAtEnemy>().LookAtVector = newPosition;
            }
        }
    }
    public void SpawnEnemy()
    {
        clearWave = false;
        //if (!waveStart)
        //{
        //    for (int i = 0; i < spawnPointCounter; i++)
        //    {
        //        Vector3 newPosition = spawnPosition();
        //        spawnPoints.Add(newPosition);
        //        GameObject lookAtSpawn = (GameObject)Instantiate(lookAtSpawnPrefab, Vector3.zero, Quaternion.identity);
        //        lookAtSpawn.GetComponent<LookAtEnemy>().LookAtVector = newPosition;
        //    }
        //}

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
        {
            waveCounter = 0;
            spawnPoints.Clear();
        }
        else
        {
            StartCoroutine(spawnerDelay(spawnDelay));
        }
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

    private void Start()
    {
        if (enemyScriptable != null)
        {
            enemyInfo = enemyScriptable;
            enemyPrefab = enemyInfo.EnemyPrefab;
            waves = enemyInfo.Waves;
            spawnDelay = enemyInfo.SpawnDelay;
        }
    }

    private void Update()
    {
        if (waveStart && enemys == 0)
        {
            waveStart = false;
            winLoseWindow.SetActive(true);
            winLoseScript.WinLoseWave(true, enemyInfo, sunHealth.LevelStars());
        }
    }
}
