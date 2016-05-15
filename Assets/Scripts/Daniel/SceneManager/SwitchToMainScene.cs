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

public class SwitchToMainScene : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    private IEnumerator Start()
    {
        SceneManager.UnloadScene("Prototyp");
        yield return SceneManager.LoadSceneAsync("MainBase", LoadSceneMode.Additive);
        Scene prototyp = SceneManager.GetSceneByName("MainBase");
        SceneManager.SetActiveScene(prototyp);
        Destroy(gameObject);
    }
}
