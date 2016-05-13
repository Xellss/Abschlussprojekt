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

public class ButtonBehaviours : MonoBehaviour
{
    private Transform credits;
    [SerializeField]
    private float normalSpeed = 1;
    private Transform startScreen;

    [SerializeField]
    private float timeScale = 0;

    // Credits
    public void OnClick_Credits()
    {
        credits.gameObject.SetActive(true);
    }

    public void OnClick_Credits_Back()
    {
        credits.gameObject.SetActive(false);
    }

    // Game Start
    public void OnClick_GameStart()
    {
        startScreen.gameObject.SetActive(false);
        Time.timeScale = normalSpeed;
    }

    // Quit
    public void OnClick_Quit()
    {
        Application.Quit();
    }

    //public void OnClick_Options_Back()
    //{
    //    options.gameObject.SetActive(false);
    //}
    // Tutorial
    public void OnClick_Tutorial()
    {
        SceneManager.LoadScene(1);
    }

    private void Awake()
    {
        startScreen = transform.FindChild("StartScreen");
        credits = startScreen.FindChild("Credit_Image");
        credits.gameObject.SetActive(false);
        Time.timeScale = timeScale;
    }

    //// Options
    //public void OnClick_Options()
    //{
    //    options.gameObject.SetActive(true);
    //}
}
