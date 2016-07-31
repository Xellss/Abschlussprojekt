﻿/////////////////////////////////////////////////
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

    private void checkList()
    {
        if (enemyList.Count == 0)
        {
            return;
        }
        else
        {
            enemyList.RemoveAll(enemy => !enemy.gameObject.activeInHierarchy);
        }
    }

    private void Start()
    {
        InvokeRepeating("checkList", 0, 0.2f);
    }
}
