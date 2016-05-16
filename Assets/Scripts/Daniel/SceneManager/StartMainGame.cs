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

public class StartMainGame : MonoBehaviour
{
    [SerializeField]
    private GameObject loadingCanvis;
    private void Awake()
    {
        DontDestroyOnLoad(this);
        DontDestroyOnLoad(loadingCanvis);

    }

    private IEnumerator Start()
    {
        yield return SceneManager.LoadSceneAsync("MainBase", LoadSceneMode.Additive);
        Scene mainBase = SceneManager.GetSceneByName("MainBase");
        loadingCanvis.SetActive(false);
        SceneManager.SetActiveScene(mainBase);
        Component.Destroy(this);
    }
}
