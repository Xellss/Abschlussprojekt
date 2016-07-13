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
    private bool clearWave = false;
    [SerializeField]
    private Edge[] edges;
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
    private List<Transform> manuelSpawnPoints;
    [SerializeField]
    private MapButtonBehaviour mapBehaviour;
    private GameObject newEnemy;
    [SerializeField]
    private bool spawn;
    private float spawnDelay;
    private int spawnPointCounter;
    [SerializeField]
    private bool spawnPointManuelSetting = false;
    private List<Vector3> spawnPoints;
    [SerializeField]
    private bool spezialSpawnPointManuelSetting = false;
    private List<Vector3> spezialSpawnPoints;
    [SerializeField]
    private BuildingHealth sunHealth;
    private List<GameObject> visualSpawnFeedbacks;
    private int waveCounter = 0;
    private Wave[] waves;
    private bool waveStart = false;
    private WinLoseWindow winLoseScript;
    [SerializeField]
    private GameObject winLoseWindow;

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
        visualSpawnFeedbacks.Clear();
        spawnPoints.Clear();
        if (!spawnPointManuelSetting)
        {
            for (int i = 0; i < Waves[waveCounter].SpawnPoints; i++)
            {
                Vector3 newPosition = spawnPosition();
                spawnPoints.Add(newPosition);
                //GameObject lookAtSpawn = (GameObject)Instantiate(lookAtSpawnPrefab, Vector3.zero, Quaternion.identity);
                //lookAtSpawn.GetComponent<LookAtEnemy>().LookAtVector = newPosition;
                //visualSpawnFeedbacks.Add(lookAtSpawn);
            }
        }
        else
        {
            for (int i = 0; i < Waves[waveCounter].SpawnPoints; i++)
            {
                Transform spawnpoint = manuelSpawnPoints[Random.Range(0, manuelSpawnPoints.Count)];
                spawnPoints.Add(spawnpoint.position);
                manuelSpawnPoints.Remove(spawnpoint);
                //GameObject lookAtSpawn = (GameObject)Instantiate(lookAtSpawnPrefab, Vector3.zero, Quaternion.identity);
                //lookAtSpawn.GetComponent<LookAtEnemy>().LookAtVector = spawnpoint.position;
                //visualSpawnFeedbacks.Add(lookAtSpawn);
            }
        }
    }

    public void SpawnEnemy()
    {
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
        if (Waves[waveCounter].SpezialWave.Enemys != null)
        {
            StartCoroutine(spezialSpawnDelay(waveCounter));
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
        visualSpawnFeedbacks = new List<GameObject>();
        spezialSpawnPoints = new List<Vector3>();
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

    private void spezialSpawn(int wavecounter)
    {
        if (!spezialSpawnPointManuelSetting)
        {
            for (int i = 0; i < Waves[wavecounter].SpezialWave.SpawnPoints; i++)
            {
                Vector3 newPosition = spawnPosition();
                spezialSpawnPoints.Add(newPosition);
                //GameObject lookAtSpawn = (GameObject)Instantiate(lookAtSpawnPrefab, Vector3.zero, Quaternion.identity);
                //lookAtSpawn.GetComponent<LookAtEnemy>().LookAtVector = newPosition;
                //visualSpawnFeedbacks.Add(lookAtSpawn);
            }
        }
        else
        {
            spawnPoints.Clear();
            spezialSpawnPoints.Clear();
            for (int i = 0; i < Waves[wavecounter].SpezialWave.SpawnPoints; i++)
            {
                Transform spawnpoint = manuelSpawnPoints[Random.Range(0, manuelSpawnPoints.Count)];
                spezialSpawnPoints.Add(spawnpoint.position);
                manuelSpawnPoints.Remove(spawnpoint);
                //GameObject lookAtSpawn = (GameObject)Instantiate(lookAtSpawnPrefab, Vector3.zero, Quaternion.identity);
                //lookAtSpawn.GetComponent<LookAtEnemy>().LookAtVector = spawnpoint.position;
                //visualSpawnFeedbacks.Add(lookAtSpawn);
            }
        }
        foreach (var spawnPoint in spezialSpawnPoints)
        {
            for (int k = 0; k < Waves[wavecounter].SpezialWave.enemyPerWave; k++)
            {
                newEnemy = ObjectPool.Instance.GetPooledObject(Waves[wavecounter].SpezialWave.Enemys);
                newEnemy.transform.position = spawnPoint;
                enemys++;
            }
        }
    }

    private IEnumerator spezialSpawnDelay(int wavecounter)
    {
        yield return new WaitForSeconds(enemyInfo.Waves[waveCounter].SpezialWave.SpawnAfterWaveBegin);
        spezialSpawn(wavecounter);
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
