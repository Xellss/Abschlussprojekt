/////////////////////////////////////////////////
///                                           ///
///      Source Code - Abschlussprojekt       ///
///                                           ///
///           Author: Daniel Lause            ///
///                                           ///
///                                           ///
/////////////////////////////////////////////////
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinLoseWindow : MonoBehaviour
{
    [SerializeField]
    private GameState gamestate;
    [SerializeField]
    private Text GoldAmount;
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

    WorldSelectionButton button;

        void Start()
    {
        button = GameObject.Find("WorldMapDetails").GetComponent<WorldSelectionButton>();
    }
    public void OnClickClose()
    {
        button.OnClickWorldMap();
    }

    public void WinLoseWave(bool winWave, EnemyWorldMapInfo enemyInfo, int stars)
    {
        if (winWave)
        {
            windowHeader.text = "Gewonnen. Du bekommst für dieses Level " + stars + " Sterne.";
            informationText.text = "Herzlichen Glückwunsch, du hast den Angriff der " + enemyInfo.EnemyGroupName + " erfolgreich abgewehrt.";
            //rewardGoldObject.SetActive(true);
            //rewardGoldText.text = enemyInfo.GoldReward.ToString();
            //gamestate.GoldAmount += enemyInfo.GoldReward;
            //GoldAmount.text = gamestate.GoldAmount.ToString();
        }
        else
        {
            windowHeader.text = "Verloren. Du bekommst keinen Stern.";
            informationText.text = "Du hast gegen die " + enemyInfo.EnemyGroupName + " verloren. Es gibt nur die Halbe beute für dich.";
            //rewardGoldObject.SetActive(true);
            //int goldReward = enemyInfo.GoldReward / 2;
            //rewardGoldText.text = goldReward.ToString();
            //gamestate.GoldAmount += goldReward;
            //GoldAmount.text = gamestate.GoldAmount.ToString();
        }
    }
}
