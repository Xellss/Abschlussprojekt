/////////////////////////////////////////////////
///                                           ///
///      Source Code - Abschlussprojekt       ///
///                                           ///
///           Author: Daniel Lause            ///
///                                           ///
///                                           ///
/////////////////////////////////////////////////
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WorldSelectionButton : MonoBehaviour
{
    private GameObject loadingText;

    private WorldMapDetails mapDetails;

    public void OnClick_StartGame()
    {
        SceneManager.LoadScene("WorldMap");
    }

    public void OnClickWorldButton(string levelName)
    {
        StartCoroutine(load(levelName));
    }

    public void OnClickWorldMap()
    {
        StartCoroutine(loadWorldMap("WorldMap"));
    }

    private void Awake()
    {
        DontDestroyOnLoad(this);
        loadingText = GameObject.Find("Loading");
        loadingText.SetActive(false);
    }

    private IEnumerator load(string levelName)
    {
        mapDetails = GetComponent<WorldMapDetails>();
        mapDetails.SaveOldLevelArray();
        yield return SceneManager.LoadSceneAsync(levelName);
        Scene mainBase = SceneManager.GetSceneByName(levelName);
        SceneManager.SetActiveScene(mainBase);
        mapDetails = GetComponent<WorldMapDetails>();
        loadingText = GameObject.Find("Loading");
        mapDetails.CurrentLevel = levelName;
        if (loadingText != null)
        {
            loadingText.SetActive(false);
            mapDetails.FillWorldMap();
        }
        //GameObject.Destroy(this.gameObject);
    }

    private IEnumerator loadWorldMap(string levelName)
    {
        yield return SceneManager.LoadSceneAsync(levelName);
        Scene mainBase = SceneManager.GetSceneByName(levelName);
        SceneManager.SetActiveScene(mainBase);
        loadingText = GameObject.Find("Loading");
        mapDetails = GetComponent<WorldMapDetails>();
        if (loadingText != null)
        {
            loadingText.SetActive(false);
            mapDetails.FillWorldMap();
        }
        //GameObject.Destroy(this.gameObject);
    }
}
