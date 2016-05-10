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
    private PoolPrefab enemyPrefab;
    private GameObject newEnemy;
    [SerializeField]
    private bool spawn;

    public void SpawnEnemy()
    {
        for (int i = 0; i < enemyCounter; i++)
        {
            newEnemy = ObjectPool.Instance.GetPooledObject(enemyPrefab);
            Vector3 position = spawnPosition();
            newEnemy.transform.position = new Vector3(position.x, 0.7f, position.z);
           
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
