/////////////////////////////////////////////////
///                                           ///
///      Source Code - Abschlussprojekt       ///
///                                           ///
///           Author: Daniel Lause            ///
///                                           ///
///                                           ///
/////////////////////////////////////////////////
using UnityEngine;

public class ClearAllLevel : MonoBehaviour
{
    [SerializeField]
    private WorldMapLevelEditor[] levels;
    private WorldMapDetails mapDetails;

    public void ClearAllLevelWith3Stars()
    {
        foreach (var level in levels)
        {
            level.StarsOnClear = 3;
            level.ClearLevel = true;
            //level.GetComponent<Button>().interactable = true;
        }
        mapDetails.FillWorldMap();
    }

    public void RemoveAllStars()
    {
        foreach (var level in levels)
        {
            level.StarsOnClear = 0;
            level.ClearLevel = false;
            //level.GetComponent<Button>().interactable = true;
        }
        mapDetails.FillWorldMap();
    }

    public void Start()
    {
        mapDetails = GameObject.Find("WorldMapDetails").GetComponent<WorldMapDetails>();
    }
}
