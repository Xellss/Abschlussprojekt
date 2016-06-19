using UnityEngine;
using System.Collections;

public class LookAtEnemy : MonoBehaviour {

	[SerializeField]
    private Vector3 lookAtVector;

    public Vector3 LookAtVector
    {
        get { return lookAtVector; }
        set { lookAtVector = value; }
    }

    void Update () {
        transform.LookAt(lookAtVector);
	}
}
