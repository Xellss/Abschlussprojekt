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
        yield return SceneManager.LoadSceneAsync("MainBase");
        Destroy(gameObject);
    }
}
