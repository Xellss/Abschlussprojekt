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
public class SpezialWave
{
    [SerializeField]
    private PoolPrefab enemys;
    [SerializeField]
    private int enemysPerWave;
    [SerializeField]
    private float spawnAfterWaveBegin;

    [SerializeField]
    private int spawnPoints;

    public int enemyPerWave
    {
        get { return enemysPerWave; }
        set { enemysPerWave = value; }
    }

    public PoolPrefab Enemys
    {
        get { return enemys; }
        set { enemys = value; }
    }

    public float SpawnAfterWaveBegin
    {
        get { return spawnAfterWaveBegin; }
        set { spawnAfterWaveBegin = value; }
    }

    public int SpawnPoints
    {
        get { return spawnPoints; }
        set { spawnPoints = value; }
    }
}
