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
        Debug.Log("Button pressed");
        shootRadius.CheckList();

        for (int i = 0; i < shootRadius.EnemyList.Count; i++)
        {
            //  shootRadius.EnemyList[i].GetComponent<EnemyKi>().CanFly = false;


            //Destroy(shootRadius.EnemyList[i].gameObject);
            //shootRadius.EnemyList[i].GetComponent<EnemyKi>().FlySpeed = 0;
        }
    }
    //    private IEnumerator stunDuration()
    //{
    //    yield return stunDuration();
    //}
}
