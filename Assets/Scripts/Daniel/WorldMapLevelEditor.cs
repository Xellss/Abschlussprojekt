using UnityEngine;
using System.Collections;

public class WorldMapLevelEditor : MonoBehaviour {

    [SerializeField]
    int levelNumber;
    WorldMapDetails worldMapDetails;
    [SerializeField]
    bool clearLevel = false;
    void Start()
    {
        worldMapDetails = GameObject.Find("WorldMapDetails").GetComponent<WorldMapDetails>();
        //clearLevel= worldMapDetails.WorldLevel[levelNumber - 1].ClearLevel;
    }

}
