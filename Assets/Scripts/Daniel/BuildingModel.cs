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
public class BuildingModel
{
    [SerializeField]
    private GameObject buildingGameObject;
    [SerializeField]
    private Transform buildingPosition;

    public Transform BuildingPosition
    {
        get { return buildingPosition; }
        set { buildingPosition = value; }
    }

    public GameObject TowerGameObject
    {
        get { return buildingGameObject; }
        set { buildingGameObject = value; }
    }

    public BuildingModel(GameObject buildingGameObject, Transform buildingTransform)
    {
        this.buildingGameObject = buildingGameObject;
        this.buildingPosition = buildingTransform;
    }
}
