using UnityEngine;
using System.Collections;

public class UpdateHPOnScreen : MonoBehaviour
{

    void OnCollisionEnter(Collision other)
    {
        print("collision goal");
        if (other.gameObject.name == "Goal")
        {
            print("goal");
            gameObject.SetActive(false);

        }
    }

    public void OnTriggerEnter(Collider other)
    {

        print("trigger goal");

    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
