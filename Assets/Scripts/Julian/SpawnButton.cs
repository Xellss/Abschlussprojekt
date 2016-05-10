/////////////////////////////////////////////////
///                                           ///
///      Source Code - Abschlussprojekt       ///
///                                           ///
///           Author: Julian Hopp             ///
///                                           ///
///                                           ///
/////////////////////////////////////////////////

using UnityEngine;
using System.Collections;

public class SpawnButton : MonoBehaviour {

    [SerializeField]
    PoolPrefab enemyPrefab;

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
        WaveCounter += 5;
    }
	
}
