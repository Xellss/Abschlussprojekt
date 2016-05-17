using UnityEngine;
using System.Collections;

public class onLoose : MonoBehaviour
{
    GameObject looseScreen;
    void Awake()
    {
        looseScreen = GameObject.Find("Lose_Image");
    }
    public void OnDestroy()
    {
        looseScreen.SetActive(true);
    }
}
