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
using System.Collections.Generic;

public class EMPButtonBehaviour : MonoBehaviour
{

    [SerializeField]
    shootRadius shootRadius;

    [SerializeField]
    float empStunDuration = 0;

    [SerializeField]
    GameObject empButton;
    List<EnemyKi> enemysInRange;

    void Start()
    {
        enemysInRange = new List<EnemyKi>();
    }

    public void OnClick_EMP()
    {
        shootRadius.CheckList();
        

        for (int i = 0; i < shootRadius.EnemyList.Count; i++)
        {
            shootRadius.EnemyList[i].GetComponent<EnemyKi>().CanFly = false;
            enemysInRange.Add(shootRadius.EnemyList[i].GetComponent<EnemyKi>());
        }

        empButton.SetActive(false);
        StartCoroutine(stunDuration());
        
    }
    private IEnumerator stunDuration()
    {
        yield return new WaitForSeconds(empStunDuration);

        for (int i = 0; i < enemysInRange.Count; i++)
        {
            enemysInRange[i].CanFly = true;
        }
    }
}
