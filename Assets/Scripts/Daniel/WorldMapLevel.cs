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
using System.Xml.Serialization;
using System.Xml;

[Serializable]
public class WorldMapLevel
{
    //[SerializeField]
    private bool clearLevel = false;
    [XmlIgnore]
    private GameObject levelButton;

    [SerializeField]
    private int starsOnClear;

    public bool ClearLevel
    {
        get { return clearLevel; }
        set { clearLevel = value; }
    }
    [XmlIgnore]
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
    public WorldMapLevel()
    {

    }
}
