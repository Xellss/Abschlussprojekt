/////////////////////////////////////////////////
///                                           ///
///      Source Code - Abschlussprojekt       ///
///                                           ///
///           Author: Julian Hopp             ///
///                                           ///
///                                           ///
/////////////////////////////////////////////////

using UnityEngine;
using UnityEngine.SceneManagement;

public class WorldSelectionButton : MonoBehaviour {

    public void OnClick_Level1()
    {
        SceneManager.LoadScene(1);
    }
    public void OnClick_Level2()
    {
        SceneManager.LoadScene(2);
    }
    public void OnClick_Level3()
    {
    SceneManager.LoadScene(3);
    }

}
