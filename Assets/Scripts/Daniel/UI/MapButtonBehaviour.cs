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

public class MapButtonBehaviour : MonoBehaviour
{
    [SerializeField]
    private GameObject attackButton;
    [SerializeField]
    private WaveSpawn waveSpawner;
    [SerializeField]
    private GameObject worldMap;

    [SerializeField]
    private Text infoText;
    [SerializeField]
    private GameObject goldRewardGameObject;
    [SerializeField]
    private GameObject itemRewardGameObject;
    [SerializeField]
    private Text goldReward;
    [SerializeField]
    private Text itemReward;


    public void OnClickAttack()
    {
        infoText.text = "Wähle einen Gegner um Informationen zu erhalten";
        attackButton.SetActive(false);
        goldRewardGameObject.SetActive(false);
        itemRewardGameObject.SetActive(false);
        worldMap.SetActive(false);
        waveSpawner.SpawnEnemy();
    }

    public void OnClickEnemyCard(EnemyEditor enemyEditor)
    {
        EnemyWorldMapInfo enemyInfo = enemyEditor.EnemyInfoScribtableObject;
        waveSpawner.EnemyPrefab = enemyInfo.EnemyPrefab;
        waveSpawner.Waves = enemyInfo.Waves;
        waveSpawner.SpawnDelay = enemyInfo.SpawnDelay;
        waveSpawner.EnemyInfo = enemyInfo;
        infoText.text = enemyInfo.WaveInformationText;
        goldReward.text = enemyInfo.GoldReward.ToString();
        goldRewardGameObject.SetActive(true);
        if (enemyInfo.ItemReward != null)
        {
            itemReward.text = enemyInfo.ItemReward.name;
            itemRewardGameObject.SetActive(true);
        }
        attackButton.SetActive(true);
    }

    public void OnClickCancel()
    {
        infoText.text = "Wähle einen Gegner um Informationen zu erhalten";
        attackButton.SetActive(false);
        goldRewardGameObject.SetActive(false);
        itemRewardGameObject.SetActive(false);
        worldMap.SetActive(false);
    }

}
