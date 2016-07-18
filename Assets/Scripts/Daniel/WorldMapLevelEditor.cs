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

public class WorldMapLevelEditor : MonoBehaviour
{
   

    private Button button;

    public Button Button
    {
        get { return button; }
        set { button = value; }
    }


    [SerializeField]
    private bool clearLevel = false;
    private int levelNumber;
    [SerializeField]
    private int starsOnClear;
    private WorldMapDetails worldMapDetails;
    private WorldSelectionButton worldSelectionButton;

    public bool ClearLevel
    {
        get { return clearLevel; }
        set { clearLevel = value; }
    }

    public int LevelNumber
    {
        get { return levelNumber; }
        set { levelNumber = value; }
    }

    public int StarsOnClear
    {
        get { return starsOnClear; }
        set { starsOnClear = value; }
    }

    public void SetButton()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(delegate { worldSelectionButton.OnClickWorldButton(this.gameObject.name); });
    }

    private void Start()
    {
        worldMapDetails = GameObject.Find("WorldMapDetails").GetComponent<WorldMapDetails>();
        worldSelectionButton = worldMapDetails.GetComponent<WorldSelectionButton>();
        //clearLevel= worldMapDetails.WorldLevel[levelNumber - 1].ClearLevel;
    }
}
