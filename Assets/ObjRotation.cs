using UnityEngine;
using System.Collections;

public class ObjRotation : MonoBehaviour
{
    public Vector3 RotationSpeed = new Vector3(0.1f, 0.1f, 0.1f);

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(RotationSpeed);
    }
}
