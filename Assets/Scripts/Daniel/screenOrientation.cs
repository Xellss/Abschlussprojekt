using UnityEngine;
using System.Collections;

public class screenOrientation : MonoBehaviour {

    void Start()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
    }
}
