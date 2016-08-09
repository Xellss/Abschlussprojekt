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

public class ObjRotation : MonoBehaviour
{
    public Vector3 RotationSpeed = new Vector3(0.1f, 0.1f, 0.1f);

    void Update()
    {
        transform.Rotate(RotationSpeed * Time.deltaTime);
    }
}
