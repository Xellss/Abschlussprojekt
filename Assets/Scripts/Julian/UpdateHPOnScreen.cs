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

public class UpdateHPOnScreen : MonoBehaviour
{
    [SerializeField]
    private int baseHP = 15;

    [SerializeField]
    private Text hPText;

    void Awake()
    {
        hPText.text = baseHP.ToString();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            baseHP -= other.gameObject.GetComponent<EnemyHP>().CurrentHealth;
            hPText.text = baseHP.ToString();
            other.gameObject.SetActive(false);
        }
    }
}
