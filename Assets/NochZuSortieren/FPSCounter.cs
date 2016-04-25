/////////////////////////////////////////////////
///                                           ///
///      Source Code - Abschlussprojekt       ///
///                                           ///
///       Author: Julian Hopp & Jöran Malek   ///
///                                           ///
///                                           ///
/////////////////////////////////////////////////

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FPSCounter : MonoBehaviour {

    [SerializeField]
    private float frequency = 0.5f;
    [SerializeField]
    private Text text;

    public int FramesPerSec { get; private set; }

    private void FixedUpdate()
    {
        transform.SetAsLastSibling();
    }

    private IEnumerator FPS()
    {
        for (;;)
        {
            // Capture frame-per-second
            int lastFrameCount = Time.frameCount;
            float lastTime = Time.realtimeSinceStartup;
            yield return new WaitForSeconds(frequency);
            float timeSpan = Time.realtimeSinceStartup - lastTime;
            int frameCount = Time.frameCount - lastFrameCount;

            // Display it
            FramesPerSec = Mathf.RoundToInt(frameCount / timeSpan);
            text.text = string.Format("FPS: {0}", FramesPerSec);
        }
    }

    private void Start()
    {
        StartCoroutine(FPS());
    }
}
