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
    [SerializeField]
    private GameObject loadingText;

    [SerializeField]
    GameObject WorldMapDetails;

    public void OnClick_StartGame()
    {
        SceneManager.LoadScene("WorldMap");
    }
    public void OnClickWorldMap()
    {
        StartCoroutine(load("WorldMap"));
        
    }

    void Awake()
    {
        DontDestroyOnLoad(this);
    }

    public void OnClickWorldButton(string levelName)
    {
        StartCoroutine(load(levelName));
        //SceneManager.LoadScene(levelName);

        //GameObject.Destroy(this.gameObject);
    }

    private IEnumerator load(string levelName)
    {
        yield return SceneManager.LoadSceneAsync(levelName);
        Scene mainBase = SceneManager.GetSceneByName(levelName);
        //loadingCanvis.SetActive(false);
        SceneManager.SetActiveScene(mainBase);
        //GameObject.Destroy(this.gameObject);
    }

}
