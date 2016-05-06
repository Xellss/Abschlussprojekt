/////////////////////////////////////////////////
///                                           ///
///      Source Code - Abschlussprojekt       ///
///                                           ///
///           Author: Julian Hopp             ///
///                                           ///
///                                           ///
/////////////////////////////////////////////////

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BackToMainBase : MonoBehaviour
{

    public void OnClick_BackToMainBase()
    {
        SceneManager.LoadScene(0);
    }
}
