/////////////////////////////////////////////////
///                                           ///
///      Source Code - Abschlussprojekt       ///
///                                           ///
///           Author: Daniel Lause            ///
///                                           ///
///                                           ///
/////////////////////////////////////////////////

using System.Linq;
using UnityEngine;

public class WorldMapDetails : MonoBehaviour
{
    private WorldMapLevelEditor currentEditor;
    private WorldMapLevel currentLevel;

    private Transform[] levelAray;
    [SerializeField]
    private Transform levelContainer;
    private WorldMapLevelEditor oldEditor;
    [SerializeField]
    private int starCount;
    [SerializeField]
    private WorldMapLevel[] worldLevel;

    public WorldMapLevel CurrentLevel
    {
        get { return currentLevel; }
        set { currentLevel = value; }
    }

    public int StarCount
    {
        get { return starCount; }
        set { starCount = value; }
    }

    public WorldMapLevel[] WorldLevel
    {
        get { return worldLevel; }
        set { worldLevel = value; }
    }

    public void RefreshStars()
    {
        if (worldLevel.Length > 0)
        {
            int stars = 0;
            for (int i = 0; i < worldLevel.Length; i++)
            {
                setStars(worldLevel[i].LevelButton, worldLevel[i].StarsOnClear);
                stars += worldLevel[i].StarsOnClear;
            }
            starCount = stars;
        }
    }

    private void fillWorldMap()
    {
        levelAray = levelContainer.Cast<Transform>().ToArray();
        worldLevel = new WorldMapLevel[levelAray.Length];

        for (int i = 0; i < worldLevel.Length; i++)
        {
            if (i > 0)
                oldEditor = currentEditor;

            currentEditor = levelAray[i].gameObject.GetComponent<WorldMapLevelEditor>();
            currentEditor.LevelNumber = i + 1;
            levelAray[i].gameObject.name = "Level" + currentEditor.LevelNumber;

            worldLevel[i] = new WorldMapLevel();
            worldLevel[i].LevelButton = currentEditor.gameObject;
            worldLevel[i].ClearLevel = currentEditor.ClearLevel;
            worldLevel[i].StarsOnClear = currentEditor.StarsOnClear;

            if (worldLevel[i].StarsOnClear > 3)
            {
                worldLevel[i].StarsOnClear = 3;
            }
            if (worldLevel[i].StarsOnClear <= 0)
            {
                worldLevel[i].StarsOnClear = 0;
                worldLevel[i].ClearLevel = false;
                currentEditor.ClearLevel = false;
            }
            else
            {
                worldLevel[i].ClearLevel = true;
                currentEditor.ClearLevel = true;
            }
            currentEditor.SetButton();
            if (oldEditor != null && !oldEditor.ClearLevel && currentEditor.LevelNumber > 1)
            {
                Debug.Log(oldEditor.name);
                Debug.Log(currentEditor.name);
                currentEditor.Button.interactable = false;
                worldLevel[i].ClearLevel = false;
                worldLevel[i].StarsOnClear = 0;
            }
        }
        RefreshStars();
    }

    private void setStars(GameObject levelObject, int starsOnClear)
    {
        if (starsOnClear == 0)
            return;

        Transform starPanel = levelObject.transform.FindChild("StarPanel");
        Transform[] stars = starPanel.Cast<Transform>().ToArray();

        for (int i = 0; i < starsOnClear; i++)
        {
            stars[i].gameObject.SetActive(true);
        }
    }

    private void Start()
    {
        fillWorldMap();
    }
}
