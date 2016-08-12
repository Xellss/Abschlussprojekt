/////////////////////////////////////////////////
///                                           ///
///      Source Code - Abschlussprojekt       ///
///                                           ///
///           Author: Daniel Lause            ///
///                                           ///
///                                           ///
/////////////////////////////////////////////////
using System.Collections.Generic;
using UnityEngine;

public class shootRadius : MonoBehaviour
{
    [SerializeField]
    private List<EnemyInfo> enemyList;

    public List<EnemyInfo> EnemyList
    {
        get { return enemyList; }
        set { enemyList = value; }
    }

    private void Awake()
    {
        enemyList = new List<EnemyInfo>();
    }

    public void CheckList()
    {
        if (enemyList.Count == 0)
        {
            //Debug.Log("List Empty");
            return;
        }
        else
        {
            enemyList.RemoveAll(enemy => !enemy.transform.gameObject.activeInHierarchy);
        }
    }

    private void Start()
    {
        InvokeRepeating("CheckList", 0, 0.1f);
    }
}
