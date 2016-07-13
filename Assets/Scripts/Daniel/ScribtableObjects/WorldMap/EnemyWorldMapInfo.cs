/////////////////////////////////////////////////
///                                           ///
///      Source Code - Abschlussprojekt       ///
///                                           ///
///           Author: Daniel Lause            ///
///                                           ///
///                                           ///
/////////////////////////////////////////////////
using UnityEngine;

[SerializeField]
public class EnemyWorldMapInfo : ScriptableObject
{
    [SerializeField]
    private string enemyGroupName;
    [SerializeField]
    private Sprite enemyMapImage;
    [SerializeField]
    private PoolPrefab enemyPrefab;
    [SerializeField]
    private int goldReward;

    [SerializeField, Tooltip("is not needed")]
    private GameObject itemReward;

    [SerializeField]
    private float spawnDelay;
    [SerializeField, TextArea]
    private string waveInformationText;

    [SerializeField]
    private Wave[] waves;

    public string EnemyGroupName
    {
        get { return enemyGroupName; }
        set { enemyGroupName = value; }
    }

    public Sprite EnemyMapImage
    {
        get { return enemyMapImage; }
        set { enemyMapImage = value; }
    }

    public PoolPrefab EnemyPrefab
    {
        get { return enemyPrefab; }
        set { enemyPrefab = value; }
    }

    public int GoldReward
    {
        get { return goldReward; }
        set { goldReward = value; }
    }

    public GameObject ItemReward
    {
        get { return itemReward; }
        set { itemReward = value; }
    }

    public float SpawnDelay
    {
        get { return spawnDelay; }
        set { spawnDelay = value; }
    }

    public string WaveInformationText
    {
        get { return waveInformationText; }
        set { waveInformationText = value; }
    }

    public Wave[] Waves
    {
        get { return waves; }
        set { waves = value; }
    }
}
