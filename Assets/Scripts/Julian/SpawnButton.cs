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

	public void SpawnEnemy()
    {
        GameObject enemy = ObjectPool.Instance.GetPooledObject(enemyPrefab);
        enemy.transform.position = new Vector3(0, 0, 0);
      
    }
	
}
