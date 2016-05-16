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

public class SwitchToOutpostScene : MonoBehaviour
{

    private void Awake()
    {
        DontDestroyOnLoad(this);

    }

    private IEnumerator Start()
    {
        SceneManager.UnloadScene("MainBase");
        yield return SceneManager.LoadSceneAsync("Prototyp",LoadSceneMode.Additive);
        Scene prototyp = SceneManager.GetSceneByName("Prototyp");
        SceneManager.SetActiveScene(prototyp);
        Destroy(gameObject);
    }
}
