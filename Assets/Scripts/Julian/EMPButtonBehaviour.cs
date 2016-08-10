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

public class EMPButtonBehaviour : MonoBehaviour
{

    [SerializeField]
    shootRadius shootRadius;

    public void OnClick_EMP()
    {
        shootRadius.CheckList();

        for (int i = 0; i < shootRadius.EnemyList.Count; i++)
        {
            shootRadius.EnemyList[i].transform.Translate(5, 5, 5);
        }

    }
}
