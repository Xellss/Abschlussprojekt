using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class GameData  {

    [SerializeField,HideInInspector]
    private WorldMapLevel[] worldMapLevel;

    public WorldMapLevel[] WorldMapLevel
    {
        get { return worldMapLevel; }
        set { worldMapLevel = value; }
    }


    public GameData(WorldMapLevel[] worldMapLevel)
    {
        this.worldMapLevel = worldMapLevel;
    }

    public GameData()
    {

    }
}
