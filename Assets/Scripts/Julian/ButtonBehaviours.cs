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
    //private Transform options;
    private Transform startScreen;

    [SerializeField]
    private float timeScale = 0;
    [SerializeField]
    private float normalSpeed = 1;
    //[SerializeField]
    //private float doubleSpeed = 1;

    private void Awake()
    {
        startScreen = transform.FindChild("StartScreen");
        credits = startScreen.FindChild("Credit_Image");
        credits.gameObject.SetActive(false);
        Time.timeScale = timeScale;
    }

    // Game Start
    public void OnClick_GameStart()
    {
        startScreen.gameObject.SetActive(false);
        Time.timeScale = normalSpeed;
    }

    // Credits
    public void OnClick_Credits()
    {
        credits.gameObject.SetActive(true);
    }

    public void OnClick_Credits_Back()
    {
        credits.gameObject.SetActive(false);
    }

    //// Options
    //public void OnClick_Options()
    //{
    //    options.gameObject.SetActive(true);
    //}

    //public void OnClick_Options_Back()
    //{
    //    options.gameObject.SetActive(false);
    //}

    // Quit
    public void OnClick_Quit()
    {
        Application.Quit();
    }
    
    // Tutorial
    public void OnClick_Tutorial()
    {
        SceneManager.LoadScene(1);
    }
    
}