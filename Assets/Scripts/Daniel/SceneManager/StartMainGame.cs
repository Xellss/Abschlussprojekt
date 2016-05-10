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
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    private IEnumerator Start()
    {
        yield return SceneManager.LoadSceneAsync("MainBase", LoadSceneMode.Additive);
        Scene mainBase = SceneManager.GetSceneByName("MainBase");
        SceneManager.SetActiveScene(mainBase);
        Component.Destroy(this);
    }
}
