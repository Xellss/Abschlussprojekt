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

public class EnemyEditor : MonoBehaviour
{
    [SerializeField]
    private Text enemyGroupName;
    [SerializeField]
    private Image enemyImage;
    [SerializeField]
    private EnemyWorldMapInfo enemyInfoScribtableObject;

    public EnemyWorldMapInfo EnemyInfoScribtableObject
    {
        get { return enemyInfoScribtableObject; }
        set { enemyInfoScribtableObject = value; }
    }

    private void editEnemyCard()
    {
        enemyGroupName.text = enemyInfoScribtableObject.EnemyGroupName;
        enemyImage.sprite = enemyInfoScribtableObject.EnemyMapImage;
        //enemyInfoText.text = enemyInfoScribtableObject.WaveInformationText;
        //goldRewardText.text = enemyInfoScribtableObject.GoldReward.ToString();
        //if (enemyInfoScribtableObject.ItemReward != null)
        //{
        //    itemRewardText.text = enemyInfoScribtableObject.ItemReward.name;
        //}
    }

    private void Start()
    {
        editEnemyCard();
    }
}
