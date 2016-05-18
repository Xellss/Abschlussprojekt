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
    [SerializeField]
    private float spawnDelay;
    [SerializeField]
    private int spawnPointCounter;
    [SerializeField]
    private List<Vector3> spawnPoints;

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

    private void Awake()
    {
        spawnPoints = new List<Vector3>();
    }

    private IEnumerator spawnerDelay(float delayTime, Vector3 spawnPosition)
    {
        yield return new WaitForSeconds(delayTime);
        newEnemy = ObjectPool.Instance.GetPooledObject(enemyPrefab);
        newEnemy.transform.position = spawnPosition;
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
}
