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


    [SerializeField]
    GameObject loadingText;


    public void OnClick_Level1()
    {
        loadingText.SetActive(true);
        SceneManager.LoadScene("Level1");
    }
    public void OnClick_Level2()
    {
        loadingText.SetActive(true);

        SceneManager.LoadScene("Level2");
    }
    public void OnClick_Level3()
    {
        loadingText.SetActive(true);
        SceneManager.LoadScene("Level3");
    }
    public void OnClick_Level4()
    {
        loadingText.SetActive(true);
        SceneManager.LoadScene("Level4");
    }
    public void OnClick_StartGame()
    {
        SceneManager.LoadScene("WorldMap");
    }
}
