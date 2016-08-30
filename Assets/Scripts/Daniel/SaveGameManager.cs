using UnityEngine;
using System.Collections;
using System.Xml.Serialization;
using System.IO;

public class SaveGameManager : MonoBehaviour
{

    private Stream stream;
    private FileInfo fileInfo = new FileInfo("saveGame.sg");
    private XmlSerializer serializer = new XmlSerializer(typeof(GameData));

    private GameData gameData;

    public GameData GameData
    {
        get { return gameData; }
        set { gameData = value; }
    }


    [SerializeField]
    private WorldMapDetails worldMapDetails;

    void Start()
    {
        gameData = new GameData(worldMapDetails.WorldLevel);
    }
    public void SaveGameData()
    {
        using (stream = fileInfo.Create())
        {
            gameData.WorldMapLevel = worldMapDetails.OldLevelArray;
            serializer.Serialize(stream, gameData);
        }
    }
    public void LoadGameData()
    {
        if (fileInfo.Exists)
        {
            using (stream = fileInfo.Open(FileMode.Open))
            {
                gameData = (GameData)serializer.Deserialize(stream);
                worldMapDetails.OldLevelArray = gameData.WorldMapLevel;
                worldMapDetails.FillWorldMap();
            }
        }
    }

    public void OnApplicationQuit()
    {
        SaveGameData();
    }

    public void OnApplicationFocus(bool focus)
    {
        if (!focus)
        {
            SaveGameData();
        }
    }
}
