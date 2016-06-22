/////////////////////////////////////////////////
///                                           ///
///      Source Code - Abschlussprojekt       ///
///                                           ///
///           Author: Daniel Lause            ///
///                                           ///
///                                           ///
/////////////////////////////////////////////////
using UnityEngine;

public class WorldMapDetails : MonoBehaviour
{
    [SerializeField]
    private int starCount;

    [SerializeField]
    private WorldMapLevel[] worldLevel;

    public int StarCount
    {
        get { return starCount; }
        set { starCount = value; }
    }

    public WorldMapLevel[] WorldLevel
    {
        get { return worldLevel; }
        set { worldLevel = value; }
    }

    private WorldMapLevel currentLevel;

    public WorldMapLevel CurrentLevel
    {
        get { return currentLevel; }
        set { currentLevel = value; }
    }

}
