using UnityEngine;
using System.Collections;

public class RandomSkybox : MonoBehaviour
{

    [SerializeField]
    private Material[] skyBoxes;

    void Awake()
    {
        if (skyBoxes != null)
        {

        RenderSettings.skybox = skyBoxes[Random.Range(0, skyBoxes.Length)];
        }

    }
}
