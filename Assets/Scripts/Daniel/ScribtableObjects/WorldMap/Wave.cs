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
    private int enemysPerWave;
    [SerializeField]
    private int spawnPoints;
    [SerializeField]
    private SpezialWave spezialWave;
    [SerializeField]
    private Transform[] wayPoints;

    public int enemyPerWave
    {
        get { return enemysPerWave; }
        set { enemysPerWave = value; }
    }

    public int SpawnPoints
    {
        get { return spawnPoints; }
        set { spawnPoints = value; }
    }

    public SpezialWave SpezialWave
    {
        get { return spezialWave; }
        set { spezialWave = value; }
    }

    public Transform[] WayPoints
    {
        get { return wayPoints; }
        set { wayPoints = value; }
    }
}
