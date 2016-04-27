using UnityEngine;
using System.Collections;

public class TimeScaleButtons : MonoBehaviour
{
    [SerializeField]
    private float Pause = 0;
    [SerializeField]
    private float SpeedOne = 1;
    [SerializeField]
    private float SpeedTwo = 2;
    [SerializeField]
    private float SpeedFour = 4;

    public void OnClick_Pause()
    {
        Time.timeScale = Pause;
    }

    public void OnClick_SpeedOne()
    {
        Time.timeScale = SpeedOne;
    }

    public void OnClick_SpeedTwo()
    {
        Time.timeScale = SpeedTwo;
    }

    public void OnClick_SpeedFour()
    {
        Time.timeScale = SpeedFour;
    }
}
