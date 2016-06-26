using UnityEngine;
using System.Collections;

public class TutorialBehavior : MonoBehaviour
{

    void Start()
    {
        Time.timeScale = 0;
    }

  public void OnButtonClick()
    {
        Time.timeScale = 1;
        this.gameObject.SetActive(false);
    }
}
