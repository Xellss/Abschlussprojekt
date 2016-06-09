using UnityEngine;
using System.Collections;

public class billboarding : MonoBehaviour
{

    GameObject MainCamera;

    public void Start()
    {
        MainCamera = GameObject.Find("Main Camera");
    }

    void FixedUpdate()
    {
        transform.LookAt(transform.position + Camera.main.transform.rotation * Vector3.forward,
          Camera.main.transform.rotation * Vector3.up);
    }
}
