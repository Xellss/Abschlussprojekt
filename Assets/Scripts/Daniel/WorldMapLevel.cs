using System;
using UnityEngine;

[Serializable]
public class WorldMapLevel
{
   [SerializeField]
    private GameObject levelButton;

    public GameObject LevelButton
    {
        get { return levelButton; }
        set { levelButton = value; }
    }

    [SerializeField]
    private bool clearLevel = false;

    public bool ClearLevel
    {
        get { return clearLevel; }
        set { clearLevel = value; }
    }

}

