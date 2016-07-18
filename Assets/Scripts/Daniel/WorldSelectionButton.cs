/////////////////////////////////////////////////
/////////////////////////////////////////////////

using System.Collections;
///                                           ///
///      Source Code - Abschlussprojekt       ///
///                                           ///
///           Author: Daniel Lause            ///
///                                           ///
///                                           ///
using UnityEngine;
using UnityEngine.SceneManagement;

public class WorldSelectionButton : MonoBehaviour
{
    private GameObject loadingText;

    WorldMapDetails mapDetails;



    public void OnClick_StartGame()
    {
        SceneManager.LoadScene("WorldMap");
    }
    public void OnClickWorldMap()
    {
        StartCoroutine(loadWorldMap("WorldMap"));
        
    }

    void Awake()
    {
        DontDestroyOnLoad(this);
        loadingText = GameObject.Find("Loading");
        loadingText.SetActive(false);
    }

    public void OnClickWorldButton(string levelName)
    {
        StartCoroutine(load(levelName));
    }

    private IEnumerator load(string levelName)
    {
        yield return SceneManager.LoadSceneAsync(levelName);
        Scene mainBase = SceneManager.GetSceneByName(levelName);
        SceneManager.SetActiveScene(mainBase);
        loadingText = GameObject.Find("Loading");
        mapDetails = GetComponent<WorldMapDetails>();
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

    void Start()
    {
    }

}
