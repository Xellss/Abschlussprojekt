using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ClearAllLevel : MonoBehaviour
{

    [SerializeField]
    WorldMapLevelEditor[] levels;
    WorldMapDetails mapDetails;
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

    public void Start()
    {
        mapDetails = GameObject.Find("WorldMapDetails").GetComponent<WorldMapDetails>();
    }
}
