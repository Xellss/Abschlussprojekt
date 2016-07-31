/////////////////////////////////////////////////
///                                           ///
///      Source Code - Abschlussprojekt       ///
///                                           ///
///           Author: Daniel Lause            ///
///                                           ///
///                                           ///
/////////////////////////////////////////////////
using System;
using UnityEngine;

[Serializable]
public class Wave
{
    [SerializeField]
    private float delayToLastWave;
    [SerializeField]
    private PoolPrefab enemyPrefab;
    [SerializeField]
    private int waveGoldReward;

    public int WaveGoldReward
    {
        get { return waveGoldReward; }
        set { waveGoldReward = value; }
    }


    [SerializeField]
    private int enemyCount;

    [SerializeField]
    private int spawnPoints;

    //[SerializeField, Tooltip("SpawnAfterClearLastWave")]
    //private bool spawnAfterClearLastWave;

    //public bool SpawnAfterClearLastWave
    //{
    //    get { return spawnAfterClearLastWave; }
    //    set { spawnAfterClearLastWave = value; }
    //}
    [SerializeField]
    private bool canBuildAfterWave;

    public bool CanBuildAfterWave
    {
        get { return canBuildAfterWave; }
        set { canBuildAfterWave = value; }
    }


    //[SerializeField]
    //private string doTweenPathContainer;

    //public string DoTweenPathContainer
    //{
    //    get { return doTweenPathContainer; }
    //    set { doTweenPathContainer = value; }
    //}


    public float DelayToLastWave
    {
        get { return delayToLastWave; }
        set { delayToLastWave = value; }
    }

    public int EnemyCount
    {
        get { return enemyCount; }
        set { enemyCount = value; }
    }

    public PoolPrefab EnemyPrefab
    {
        get { return enemyPrefab; }
        set { enemyPrefab = value; }
    }

    public int SpawnPoints
    {
        get { return spawnPoints; }
        set { spawnPoints = value; }
    }

}
