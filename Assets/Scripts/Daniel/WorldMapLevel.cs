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
public class WorldMapLevel
{
    [SerializeField]
    private bool clearLevel = false;
    [SerializeField]
    private GameObject levelButton;

    [SerializeField]
    private int starsOnClear;

    public bool ClearLevel
    {
        get { return clearLevel; }
        set { clearLevel = value; }
    }

    public GameObject LevelButton
    {
        get { return levelButton; }
        set { levelButton = value; }
    }

    public int StarsOnClear
    {
        get { return starsOnClear; }
        set { starsOnClear = value; }
    }
}
