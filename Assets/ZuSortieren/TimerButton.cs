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
using UnityEngine.UI;

public class TimerButton : MonoBehaviour
{
    [SerializeField]
    private Text TimerTime;

    public void Awake()
    {
        //float timerTime = GetComponent<Timer>().TimerTime;
        

    }

    public void OnClick_timer()
    {
        TimerTime.text = 0.ToString();
    }
}
