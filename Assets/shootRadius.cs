using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class shootRadius : MonoBehaviour {

    private List<Transform> enemyList;

    public List<Transform> EnemyList
    {
        get { return enemyList; }
        set { enemyList = value; }
    }

    void Start()
    {
        enemyList = new List<Transform>();
    }
}
