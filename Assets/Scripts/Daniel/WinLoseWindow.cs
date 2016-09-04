/////////////////////////////////////////////////
///                                           ///
///      Source Code - Abschlussprojekt       ///
///                                           ///
///           Author: Daniel Lause            ///
///                                           ///
///                                           ///
/////////////////////////////////////////////////
using UnityEngine;
using UnityEngine.UI;

public class WinLoseWindow : MonoBehaviour
{
    [SerializeField]
    private GameState gamestate;
    [SerializeField]
    private Text informationText;
    [SerializeField]
    private GameObject rewardGoldObject;
    [SerializeField]
    private Text rewardGoldText;
    [SerializeField]
    private GameObject rewardItemObject;
    [SerializeField]
    private Text rewardItemText;
    [SerializeField]
    private Text windowHeader;

    WorldMapDetails mapDetails;

    WorldSelectionButton button;

        void Start()
    {
    }
    public void OnClickClose()
    {
        button.OnClickWorldMap();
    }

    public void WinLoseWave(bool winWave, EnemyWorldMapInfo enemyInfo, int stars)
    {
        mapDetails = GameObject.Find("WorldMapDetails").GetComponent<WorldMapDetails>();
        button = GameObject.Find("WorldMapDetails").GetComponent<WorldSelectionButton>();
        if (winWave)
        {
            mapDetails.CurrentLevelStarCount = stars;
            windowHeader.text = "Gewonnen. Du bekommst für dieses Level " + stars + " Sterne.";
            informationText.text = "Herzlichen Glückwunsch, du hast den Angriff der " + enemyInfo.EnemyGroupName + " erfolgreich abgewehrt.";
        }
        else
        {
            mapDetails.CurrentLevelStarCount = stars;
            windowHeader.text = "Verloren. Du bekommst keinen Stern.";
            informationText.text = "Du hast gegen die " + enemyInfo.EnemyGroupName + " verloren. Es gibt nur die Halbe beute für dich.";
        }
    }
}
