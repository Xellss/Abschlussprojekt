/////////////////////////////////////////////////
///                                           ///
///      Source Code - Abschlussprojekt       ///
///                                           ///
///           Author: Daniel Lause            ///
///                                           ///
///                                           ///
/////////////////////////////////////////////////
using UnityEngine;

public class RestartLevel : MonoBehaviour
{
    private WorldSelectionButton button;
    private WorldMapDetails mapDetails;

    public void OnClickClose()
    {
        this.gameObject.SetActive(false);
    }

    public void OnClickRestart()
    {
        mapDetails = GameObject.Find("WorldMapDetails").GetComponent<WorldMapDetails>();
        button = GameObject.Find("WorldMapDetails").GetComponent<WorldSelectionButton>();
        mapDetails.CurrentLevelStarCount = 0;
        button.OnClickWorldButton(mapDetails.CurrentLevel);
    }

    public void OnClickWorldMap()
    {
        mapDetails = GameObject.Find("WorldMapDetails").GetComponent<WorldMapDetails>();
        button = GameObject.Find("WorldMapDetails").GetComponent<WorldSelectionButton>();
        mapDetails.CurrentLevelStarCount = 0;
        button.OnClickWorldMap();
    }
}
