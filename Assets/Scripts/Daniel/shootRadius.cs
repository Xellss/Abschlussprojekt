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
    private List<Transform> enemyList;

    public List<Transform> EnemyList
    {
        get { return enemyList; }
        set { enemyList = value; }
    }

    private void Awake()
    {
        enemyList = new List<Transform>();
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
            enemyList.RemoveAll(enemy => !enemy.gameObject.activeInHierarchy);
        }
    }

    private void Start()
    {
        InvokeRepeating("CheckList", 0, 0.1f);
    }
}
