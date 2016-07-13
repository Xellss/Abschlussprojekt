/////////////////////////////////////////////////
///                                           ///
///      Source Code - Abschlussprojekt       ///
///                                           ///
///           Author: Daniel Lause            ///
///                                           ///
///                                           ///
/////////////////////////////////////////////////
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

public class WorldSelectionButton : MonoBehaviour
{
    [SerializeField]
    private GameObject loadingText;

    public void OnClick_StartGame()
    {
        SceneManager.LoadScene("WorldMap");
    }

    public void OnClickWorldButton(string levelName)
    {
        loadingText.SetActive(true);
        SceneManager.LoadScene(levelName);
    }
}
