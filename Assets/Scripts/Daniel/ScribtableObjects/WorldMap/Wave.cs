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

    public int enemyPerWave
    {
        get { return enemysPerWave; }
        set { enemysPerWave = value; }
    }
}
