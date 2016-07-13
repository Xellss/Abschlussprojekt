/////////////////////////////////////////////////
///                                           ///
///      Source Code - Abschlussprojekt       ///
///                                           ///
///           Author: Daniel Lause            ///
///                                           ///
///                                           ///
/////////////////////////////////////////////////
using UnityEngine;

public class RandomSkybox : MonoBehaviour
{
    [SerializeField]
    private Material[] skyBoxes;

    private void Awake()
    {
        if (skyBoxes != null)
        {
            RenderSettings.skybox = skyBoxes[Random.Range(0, skyBoxes.Length)];
        }
    }
}
