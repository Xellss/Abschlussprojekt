using UnityEngine;
using System.Collections;

public class onLoose : MonoBehaviour
{
    [SerializeField]
    private GameObject loseScreen;

    public GameObject LoseScreen
    {
        get { return loseScreen; }
        set { loseScreen = value; }
    }

    void Awake()
    {
        loseScreen.SetActive(false);
    }
}
