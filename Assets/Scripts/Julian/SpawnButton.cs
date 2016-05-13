/////////////////////////////////////////////////
///                                           ///
///      Source Code - Abschlussprojekt       ///
///                                           ///
///           Author: Julian Hopp             ///
///                                           ///
///                                           ///
/////////////////////////////////////////////////

using UnityEngine;

public class SpawnButton : MonoBehaviour
{
    [SerializeField]
    private PoolPrefab enemyPrefab;

    private int WaveCounter = 1;

    public void SpawnEnemy()
    {
        GameObject enemy = ObjectPool.Instance.GetPooledObject(enemyPrefab);
        enemy.transform.position = new Vector3(0, 0, 0);
    }

    public void SpawnEnemyWave()
    {
        for (int i = 0; i < WaveCounter; i++)
        {
            GameObject enemy = ObjectPool.Instance.GetPooledObject(enemyPrefab);
            enemy.transform.position = new Vector3(0, 0, 0);
        }
        WaveCounter += 4;
    }
}
