/////////////////////////////////////////////////
///                                           ///
///      Source Code - Abschlussprojekt       ///
///                                           ///
///           Author: Daniel Lause            ///
///                                           ///
///                                           ///
/////////////////////////////////////////////////
using UnityEngine;

public class WaveSpawn : MonoBehaviour
{
    [SerializeField]
    private Edge[] edges;
    [SerializeField]
    private int enemyCounter;
    [SerializeField]
    private GameObject enemyPrefab;
    private GameObject newEnemy;
    [SerializeField]
    private bool spawn;

    public void SpawnEnemy()
    {
        for (int i = 0; i < enemyCounter; i++)
        {
            newEnemy = (GameObject)Instantiate(enemyPrefab, spawnPosition(), Quaternion.identity);
        }
    }

    private Vector3 spawnPosition()
    {
        int sideNumber = Random.Range(0, edges.Length);

        Edge edge = edges[sideNumber];

        return Vector3.Lerp(edge.First.position, edge.Second.position, Random.value);
    }

    private void Update()
    {
        if (spawn)
        {
            spawn = false;
            SpawnEnemy();
        }
    }
}
