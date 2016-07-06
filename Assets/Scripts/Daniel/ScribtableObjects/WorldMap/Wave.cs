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
    private Transform[] wayPoints;

    public Transform[] WayPoints
    {
        get { return wayPoints; }
        set { wayPoints = value; }
    }

    [SerializeField]
    private int enemysPerWave;

    public int enemyPerWave
    {
        get { return enemysPerWave; }
        set { enemysPerWave = value; }
    }
    [SerializeField]
    private int spawnPoints;

    public int SpawnPoints
    {
        get { return spawnPoints; }
        set { spawnPoints = value; }
    }
    [SerializeField]
    private SpezialWave spezialWave;

    public SpezialWave SpezialWave
    {
        get { return spezialWave; }
        set { spezialWave = value; }
    }


}
