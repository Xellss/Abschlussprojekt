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
        yield return SceneManager.LoadSceneAsync("Prototyp");
        Destroy(gameObject);
    }
}
