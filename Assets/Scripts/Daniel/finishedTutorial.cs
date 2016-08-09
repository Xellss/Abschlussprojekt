using UnityEngine;
using System.Collections;

public class finishedTutorial : MonoBehaviour
{

    [SerializeField]
    Tutorial tutorial;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "tutorial")
        {
            tutorial.RotateTutClear = true;
        }
    }
}
