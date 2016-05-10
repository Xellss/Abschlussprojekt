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
public class TerrainModel
{
    [SerializeField]
    private GameObject terrainGameObject;
    [SerializeField]
    private Transform terrainPosition;
    [SerializeField]
    private bool unlockedTerrain;

    public GameObject TerrainGameObject
    {
        get { return terrainGameObject; }
        set { terrainGameObject = value; }
    }

    public Transform TerrainPosition
    {
        get { return terrainPosition; }
        set { terrainPosition = value; }
    }

    public bool UnlockedTerrain
    {
        get { return unlockedTerrain; }
        set { unlockedTerrain = value; }
    }

    public TerrainModel(GameObject terrainGameObject, Transform terrainPosition, bool unlockedTerrain)
    {
        this.terrainGameObject = terrainGameObject;
        this.terrainPosition = terrainPosition;
        this.unlockedTerrain = unlockedTerrain;
    }
}
