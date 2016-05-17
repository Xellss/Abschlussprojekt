/////////////////////////////////////////////////
/////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
///                                           ///
///      Source Code - Abschlussprojekt       ///
///                                           ///
///           Author: Daniel Lause            ///
///                                           ///
///                                           ///
using UnityEngine;

public class WaveSpawn : MonoBehaviour
{
    [SerializeField]
    private Edge[] edges;
    [SerializeField]
    private int spawnPointCounter;
    [SerializeField]
    private int enemyCountPerSpawnPoint;
    [SerializeField]
    private PoolPrefab enemyPrefab;
    [SerializeField]
    private bool spawn;
    [SerializeField]
    private float spawnDelay;

    [SerializeField]
    private List<Vector3> spawnPoints;


    private GameObject newEnemy;

    void Awake()
    {
        spawnPoints = new List<Vector3>();
    }

    public void SpawnEnemy()
    {
        for (int i = 0; i < spawnPointCounter; i++)
        {
            spawnPoints.Add(spawnPosition());
        }

        foreach (var spawnPoint in spawnPoints)
        {
            for (int k = 0; k < enemyCountPerSpawnPoint; k++)
            {
                StartCoroutine(spawnerDelay(spawnDelay, spawnPoint));
            }
        }
        spawnPoints.Clear();
    }

    private Vector3 spawnPosition()
    {
        int sideNumber = Random.Range(0, edges.Length);

        Edge edge = edges[sideNumber];

        return Vector3.Lerp(edge.First.position, edge.Second.position, Random.value);
    }

    private void Update()
    {
        //if (spawn)
        //{
        //    spawn = false;
        //    SpawnEnemy();
        //}
    }

    IEnumerator spawnerDelay(float delayTime, Vector3 spawnPosition)
    {
        yield return new WaitForSeconds(delayTime);
        newEnemy = ObjectPool.Instance.GetPooledObject(enemyPrefab);
        newEnemy.transform.position = spawnPosition;

    }
}
