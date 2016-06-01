/////////////////////////////////////////////////
///                                           ///
///      Source Code - Abschlussprojekt       ///
///                                           ///
///           Author: Julian Hopp             ///
///                                           ///
///                                           ///
/////////////////////////////////////////////////

using UnityEngine;

public class PlayPauseButton : MonoBehaviour
{
    [SerializeField]
    private int IsGameRunning = 1;

    public void OnClick_Play_Pause_Button()
    {
        if (IsGameRunning == 1)
        {
            IsGameRunning = 0;
        }
        else
        {
            IsGameRunning = 1;
        }
        Time.timeScale = IsGameRunning;
    }
}
