using UnityEngine;
using System.Collections;

public class billboarding : MonoBehaviour
{

    [SerializeField]
    GameObject MainCamera;

    public void Start()
    {
        MainCamera = GameObject.Find("Main Camera");
    }

    void Update()
    {
        transform.LookAt(transform.position + MainCamera.transform.rotation * Vector3.forward,
          MainCamera.transform.rotation * Vector3.up);
    }
}
